using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoointWebApi.Data.Repositories;
using PoointWebApi.Model;
using System.Threading.Tasks;

namespace PoointWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {

        private readonly ITareaRepository _tareaRepository;

        public TareaController(ITareaRepository tareaRepository)
        {
            _tareaRepository = tareaRepository;
        }

        [HttpGet]
        [Route("GetSubGrupByGrupoId")]
        public async Task<IActionResult> GetTarea([FromQuery] Tarea Tarea)
        {
            return Ok(await _tareaRepository.GetTarea(Tarea));
        }

        [HttpPost]
        public async Task<IActionResult> InsertSubGrupos([FromBody] Tarea Tarea)
        {
            if (Tarea == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _tareaRepository.InsertTarea(Tarea);

            return Created("created", created);
        }

    }
}
