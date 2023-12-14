using Microsoft.AspNetCore.Mvc;
using TreinoPI.Contracts.Repository;
using TreinoPI.Repository;

namespace TreinoPI.Controllers
{
    [ApiController]
    [Route("ModeloContratacao")]
    public class ModeloContratacaoController : ControllerBase
    {
        private readonly IModeloContratacaoRepository _ModeloContratacaoRepository;

        public ModeloContratacaoController(IModeloContratacaoRepository modeloContratacaoRepository)
        {
            _ModeloContratacaoRepository = modeloContratacaoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _ModeloContratacaoRepository.Get());
        }
    }
}