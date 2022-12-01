using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoointWebApi.Data.Repositories;
using PoointWebApi.Model;
using System.Threading.Tasks;

namespace PoointWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioAController : ControllerBase
    {
        private readonly IComentarioARepository _comentarioARepository;

        public ComentarioAController(IComentarioARepository comentarioARepository)
        {
            _comentarioARepository = comentarioARepository;
        }

        [HttpGet]
        [Route("GetComentarioAById")]
        public async Task<IActionResult> GetAvisos([FromQuery] ComentarioAvi ComentarioAvi)
        {
            return Ok(await _comentarioARepository.GetConentarioIdA(ComentarioAvi));
        }

        [HttpPost]
        public async Task<IActionResult> InsertAviso([FromBody] ComentarioAvi ComentarioAvi)
        {
            if (ComentarioAvi == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _comentarioARepository.InsertConentarioA(ComentarioAvi);

            return Created("Participante created", created);
        }
    }
}
