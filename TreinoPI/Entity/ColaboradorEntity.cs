

using System.Security.Policy;

namespace TreinoPI.Entity
{
    public class ColaboradorEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Contato { get; set; }
        public string Endereco { get; set; }
        public string Cargo { get; set; }
        public string Empresa { get; set; }
        public int ModeloContratacaoId { get; set; }
        public string Senha { get; set; }
        
    }
}
