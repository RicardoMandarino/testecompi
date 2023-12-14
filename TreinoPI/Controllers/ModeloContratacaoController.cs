using Microsoft.AspNetCore.Mvc;
using TreinoPI.Contracts.Repository;

namespace TreinoPI.Controllers
{
    [ApiController]
    [Route("ModeloContratacao")]
    public class ModeloContratacaoController : ControllerBase
    {
        private readonly IModeloContratacaoRepository _ModeloContratacaoRepository;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _ModeloContratacaoRepository.Get());
        }
    }
}
