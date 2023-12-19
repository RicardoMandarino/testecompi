using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            return Ok(await _colaboradorRepository.GetByEmail(email));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(ColaboradorDTO colaborador)
        {
            await _colaboradorRepository.Add(colaborador);
            return Ok();
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update(ColaboradorDTO colaborador)
        {
            await _colaboradorRepository.Update(colaborador);
            return Ok();
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete(string email)
        {
            await _colaboradorRepository.Delete(email);
            return Ok();
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LogIn(UserLoginDTO user)
        {
            try
            {
                return Ok(await _colaboradorRepository.LogIn(user));
            }
            
            catch(Exception ex)
            {
               return Unauthorized("Usuario ou Senha Invalida");
            }
        }
    }
}
