using PoointWebApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PoointWebApi.Data.Repositories
{
    public interface IChatTeamsMessagesRepository
    {
        Task<bool> InsertChatTeamsMessages(ChatTeamsMessages chatMessage);
        Task<IEnumerable<ChatTeamsMessagesData>> GetChatsTeamsById(ChatTeamsMessagesId chatMessage);
    }
}
