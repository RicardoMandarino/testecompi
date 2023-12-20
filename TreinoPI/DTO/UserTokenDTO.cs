using TreinoPI.Entity;

namespace TreinoPI.DTO
{
    public class UserTokenDTO
    {
        public string Token { get; set; }
        public ColaboradorEntity User { get; set; }
    }
}
