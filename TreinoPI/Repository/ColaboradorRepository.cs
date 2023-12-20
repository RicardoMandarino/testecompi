using Dapper;
using TreinoPI.Contracts.Repository;
using TreinoPI.DTO;
using TreinoPI.Entity;
using TreinoPI.Infrastructure;

namespace TreinoPI.Repository
{
    public class ColaboradorRepository : Connection, IColaboradorRepository
    {
        public async Task Add(ColaboradorDTO colaborador)
        {
            string sql = @"
                INSERT INTO COLABORADOR (Nome, Email, Contato, Endereco, Cargo, Empresa, ModeloContratacaoId, Senha, Roles)
                            VALUE (@Nome, @Email, @Contato, @Endereco, @Cargo, @Empresa, @ModeloContratacaoId, @Senha, @Roles)            
            ";
            await Execute(sql,colaborador);
        }

        public async Task Delete(string email)
        {
            string sql = "DELETE FROM COLABORADOR WHERE Email = @email";
            await Execute(sql, new {email});
        }

        public async Task<IEnumerable<ColaboradorEntity>> Get()
        {
            string sql = "SELECT * FROM COLABORADOR";
            return await GetConnection().QueryAsync<ColaboradorEntity>(sql);
        }

        public async Task<UserLoginDTO> GetByEmail(string email)
        {
            string sql = "SELECT EMAIL,SENHA FROM COLABORADOR WHERE Email = @email";
            return await GetConnection().QueryFirstAsync<UserLoginDTO>(sql, new { email });
        }

        public async Task<UserTokenDTO> LogIn(UserLoginDTO user)
        {
            string sql = "SELECT * FROM colaborador WHERE Email = @Email AND Senha = @Senha";
            ColaboradorEntity userLogin = await GetConnection().QueryFirstAsync<ColaboradorEntity>(sql, user);
            return new UserTokenDTO
            {
                Token = Authentication.GenerateToken(userLogin),
                User = userLogin
            };
                     
            
        }

        public async Task Update(ColaboradorDTO colaborador)
        {
            string sql = @"
               UPDATE COLABORADOR
                    SET Nome = @Nome,
                        Email = @Email,
                        Contato = @Contato,
                        Endereco = @Endereco,
                        Cargo = @Cargo,
                        Empresa = @Empresa,
                        ModeloContratacaoId = @ModeloContratacaoId,
                        Senha = @Senha
                        Roles = @Roles
                WHERE Email = @Email
           ";
            await Execute(sql, colaborador);

        }
    }
}
