using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoointWebApi.Data.Repositories;
using PoointWebApi.Model;
using System.Threading.Tasks;

namespace PoointWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatTeamsMessagesController : ControllerBase
    {
        private readonly IChatTeamsMessagesRepository _chatTeamsMessageRepository;
        public ChatTeamsMessagesController(IChatTeamsMessagesRepository chatTeamsMessageRepository)
        {
            _chatTeamsMessageRepository = chatTeamsMessageRepository;
        }

        [HttpPost]
        public async Task<IActionResult> InsertChatTeamsMessages([FromBody] ChatTeamsMessages chatTeamsMessage)
        {
            if (chatTeamsMessage == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _chatTeamsMessageRepository.InsertChatTeamsMessages(chatTeamsMessage);

            return Created("created", created);
        }

        [HttpGet]
        [Route("GetChatsTeamsMessages")]
        public async Task<IActionResult> GetChatsTeamsById([FromQuery] ChatTeamsMessagesId chatTeamsMessage)
        {
            return Ok(await _chatTeamsMessageRepository.GetChatsTeamsById(chatTeamsMessage));
        }
    }
}
