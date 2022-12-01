using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoointWebApi.Data.Repositories;
using PoointWebApi.Model;
using System.Threading.Tasks;

namespace PoointWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvisosController : ControllerBase
    {
        private readonly IAvisosRepository _AvisosRepository;

        public AvisosController(IAvisosRepository AvisosRepository)
        {
            _AvisosRepository = AvisosRepository;
        }

        [HttpGet]
        [Route("GetAvisoByGrupoId")]
        public async Task<IActionResult> GetAvisos([FromQuery] Avisos Avisos)
        {
            return Ok(await _AvisosRepository.GetAvisos(Avisos));
        }

        [HttpPost]
        public async Task<IActionResult> InsertAviso([FromBody] Avisos Avisos)
        {
            if (Avisos == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _AvisosRepository.InsertAviso(Avisos);

            return Created("Aviso created", created);
        }

    }
}
