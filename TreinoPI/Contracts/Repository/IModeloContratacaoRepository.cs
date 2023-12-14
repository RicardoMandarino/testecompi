using TreinoPI.Entity;

namespace TreinoPI.Contracts.Repository
{
    public interface IModeloContratacaoRepository
    {
        Task<IEnumerable<ModeloContratacaoEntity>> Get();
    }
}
