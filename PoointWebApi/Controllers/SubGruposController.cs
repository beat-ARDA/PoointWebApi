using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoointWebApi.Data.Repositories;
using PoointWebApi.Model;
using System.Threading.Tasks;

namespace PoointWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubGruposController : ControllerBase
    {
        private readonly ISubGruposRepository _SubGruposRepository;

        public SubGruposController(ISubGruposRepository SubGruposRepository)
        {
            _SubGruposRepository = SubGruposRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSubGrupos()
        {
            return Ok(await _SubGruposRepository.GetAllSubGrupos());
        }

        [HttpGet]
        [Route("GetSubGrupByGrupoId")]
        public async Task<IActionResult> GetSubGrupos([FromQuery] SubGrupo subGrupo)
        {
            return Ok(await _SubGruposRepository.GetSubGrupos(subGrupo));
        }

        [HttpGet]
        [Route("GetSubGrupBySGId")]
        public async Task<IActionResult> GetSubGruposIDSG([FromQuery] SubGrupo SGrupo)
        {
            return Ok(await _SubGruposRepository.GetSubGruposIDSG(SGrupo));
        }

        [HttpPost]
        public async Task<IActionResult> InsertSubGrupos([FromBody] SubGrupo subGrupo)
        {
            if (subGrupo == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _SubGruposRepository.InsertSubGrupos(subGrupo);

            return Created("created", created);
        }

        

    }
}
