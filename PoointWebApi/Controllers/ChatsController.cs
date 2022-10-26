using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using PoointWebApi.Data.Repositories;
using PoointWebApi.Model;
using System.Threading.Tasks;

namespace PoointWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatsController : ControllerBase
    {
        private readonly IChatsRepository _chatRepository;
        public ChatsController(IChatsRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }

        [HttpPost]
        [Route("InsertChat")]
        public async Task<IActionResult> InsertChat([FromBody] Chats chat)
        {
            if (chat == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _chatRepository.InsertChat(chat);

            return Created("created", created);
        }

        [HttpGet]
        [Route("GetChatsByUserId")]
        public async Task<IActionResult> GetChatsByUserId([FromQuery] ChatsById chat)
        {
            return Ok(await _chatRepository.GetChatsByUserId(chat));
        }

        [HttpDelete]
        [Route("DeleteChatById")]
        public async Task<IActionResult> DeleteChatById([FromBody] ChatsById chat)
        {
            return Ok(await _chatRepository.DeleteChatById(chat));
        }

        [HttpGet]
        [Route("GetChatByIds")]
        public async Task<IActionResult> GetChatByIds([FromQuery] ChatsIds chat)
        {
            return Ok(await _chatRepository.GetChatByIds(chat));
        }
    }
}
