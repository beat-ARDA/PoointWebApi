using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoointWebApi.Data.Repositories;
using PoointWebApi.Model;
using System.Threading.Tasks;

namespace PoointWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatsTeamsUsersController : ControllerBase
    {
        private readonly IChatsTeamsUsersRepository _chatsTeamsUsersRepository;
        public ChatsTeamsUsersController(IChatsTeamsUsersRepository chatsTeamsUsersRepository)
        {
            _chatsTeamsUsersRepository = chatsTeamsUsersRepository;
        }

        [HttpPost]
        [Route("InsertChatTeamUser")]
        public async Task<IActionResult> InsertChatTeamUser([FromBody] ChatsTeamsUsers chatTeamUser)
        {
            if (chatTeamUser == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _chatsTeamsUsersRepository.InsertChatTeamUser(chatTeamUser);

            return Created("created", created);
        }

        [HttpGet]
        [Route("GetChatsTeamsUserByUserId")]
        public async Task<IActionResult> GetChatsTeamsUserByUserId([FromQuery] ChatsTeamsUsersId chat)
        {
            return Ok(await _chatsTeamsUsersRepository.GetChatsTeamsUserByUserId(chat));
        }
    }
}
