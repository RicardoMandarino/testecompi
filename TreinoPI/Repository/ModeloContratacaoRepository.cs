using Dapper;
using TreinoPI.Contracts.Repository;
using TreinoPI.Entity;
using TreinoPI.Infrastructure;

namespace TreinoPI.Repository
{
    public class ModeloContratacaoRepository : Connection, IModeloContratacaoRepository
    {
        public async Task<IEnumerable<ModeloContratacaoEntity>> Get()
        {
            string sql = "SELECT * FROM MODELOCONTRATACAO";
            return await GetConnection().QueryAsync<ModeloContratacaoEntity>(sql);
        }
    }
}
