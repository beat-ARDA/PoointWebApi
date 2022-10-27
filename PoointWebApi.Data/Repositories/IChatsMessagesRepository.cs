using PoointWebApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PoointWebApi.Data.Repositories
{
    public interface IChatsMessagesRepository
    {
        Task<bool> InsertChatsMessages(ChatMessage chatMessage);
        Task<IEnumerable<ChatMessageData>> GetChatsById(ChatMessageId chatMessage);
    }
}
