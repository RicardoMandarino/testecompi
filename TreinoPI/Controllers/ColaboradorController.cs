using Microsoft.AspNetCore.Mvc;
using TreinoPI.Contracts.Repository;
using TreinoPI.DTO;
using TreinoPI.Entity;

namespace TreinoPI.Controllers
{
    [ApiController]
    [Route("Colaborador")]
    public class ColaboradorController : ControllerBase
    {
        private readonly IColaboradorRepository _colaboradorRepository;

        public ColaboradorController(IColaboradorRepository colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _colaboradorRepository.Get());
        }
        
        [HttpPost]
        public async Task<IActionResult> Add(ColaboradorDTO colaborador)
        {
            await _colaboradorRepository.Add(colaborador);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(ColaboradorDTO colaborador)
        {
            await _colaboradorRepository.Update(colaborador);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string email)
        {
            await _colaboradorRepository.Delete(email);
            return Ok();
        }
    }
}
