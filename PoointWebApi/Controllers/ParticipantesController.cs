using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoointWebApi.Data.Repositories;
using PoointWebApi.Model;
using System.Threading.Tasks;

namespace PoointWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantesController : ControllerBase
    {
        private readonly IParticipantesRepository _participantesRepository;

        public ParticipantesController(IParticipantesRepository participantesRepository)
        {
            _participantesRepository = participantesRepository;
        }

        [HttpGet]
        [Route("GetSubGrupByGrupoId")]
        public async Task<IActionResult> GetSubGrupos([FromQuery] Participantes participantes)
        {
            return Ok(await _participantesRepository.GetParticipante(participantes));
        }

        [HttpPost]
        public async Task<IActionResult> InsertSubGrupos([FromBody] Participantes participantes)
        {
            if (participantes == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _participantesRepository.InsertParticipantes(participantes);

            return Created("Participante created", created);
        }

    }
}
