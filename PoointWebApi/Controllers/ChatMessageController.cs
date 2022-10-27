using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoointWebApi.Data.Repositories;
using PoointWebApi.Model;
using System.Threading.Tasks;

namespace PoointWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatMessageController : ControllerBase
    {
        private readonly IChatsMessagesRepository _chatMessageRepository;
        public ChatMessageController(IChatsMessagesRepository chatMessageRepository)
        {
            _chatMessageRepository = chatMessageRepository;
        }

        [HttpPost]
        public async Task<IActionResult> InsertChatsMessages([FromBody] ChatMessage chatMessage)
        {
            if (chatMessage == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _chatMessageRepository.InsertChatsMessages(chatMessage);

            return Created("created", created);
        }

        [HttpGet]
        [Route("GetChatsMessages")]
        public async Task<IActionResult> GetChatsById([FromQuery] ChatMessageId chatMessage)
        {
            return Ok(await _chatMessageRepository.GetChatsById(chatMessage));
        }
    }
}
