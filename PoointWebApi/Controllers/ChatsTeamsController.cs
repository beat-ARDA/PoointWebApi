using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoointWebApi.Data.Repositories;
using PoointWebApi.Model;
using System.Threading.Tasks;

namespace PoointWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatsTeamsController : ControllerBase
    {
        private readonly IChatsTeamsRepository _chatTeamsRepository;
        public ChatsTeamsController(IChatsTeamsRepository chatTeamsRepository)
        {
            _chatTeamsRepository = chatTeamsRepository;
        }

        [HttpPost]
        [Route("InsertChatTeam")]
        public async Task<IActionResult> InsertChatTeams([FromBody] ChatsTeams chatTeams)
        {
            if (chatTeams == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _chatTeamsRepository.InsertChatTeam(chatTeams);

            return Created("created", created);
        }

        [HttpDelete]
        [Route("DeleteChatTeamById")]
        public async Task<IActionResult> DeleteChatTeamById([FromBody] ChatsTeamsById chatTeam)
        {
            return Ok(await _chatTeamsRepository.DeleteChatTeamById(chatTeam));
        }
    }
}
