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
                INSERT INTO COLABORADOR (Nome, Email, Contato, Endereco, Cargo, Empresa, ModeloContratacaoId, Senha)
                            VALUE (@Nome, @Email, @Contato, @Endereco, @Cargo, @Empresa, @ModeloContratacaoId, @Senha)            
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

        public async Task<LoginDTO> GetByEmail(string email)
        {
            string sql = "SELECT EMAIL,SENHA FROM COLABORADOR WHERE Email = @email";
            return await GetConnection().QueryFirstAsync<LoginDTO>(sql, new { email });
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
                WHERE Email = @Email
           ";
            await Execute(sql, colaborador);

        }
    }
}
