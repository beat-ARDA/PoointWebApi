using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoointWebApi.Data.Repositories;
using PoointWebApi.Model;
using System.Threading.Tasks;

namespace PoointWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareasController : ControllerBase
    {
        private readonly ITareasRepository _tareasRepository;

        public TareasController(ITareasRepository tareasRepository)
        {
            _tareasRepository = tareasRepository;
        }

        [HttpGet]
        [Route("GetTareasBySGrupoId")]
        public async Task<IActionResult> GetTareasGrupo([FromQuery] Tareas Tareas)
        {
            return Ok(await _tareasRepository.GetTareasGrupo(Tareas));
        }

        [HttpPost]
        public async Task<IActionResult> InsertTareas([FromBody] Tareas Tareas)
        {
            if (Tareas == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _tareasRepository.InsertTareas(Tareas);

            return Created("created", created);
        }

    }
}
