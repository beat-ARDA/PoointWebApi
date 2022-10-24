using PoointWebApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PoointWebApi.Data.Repositories
{
    public interface IChatsRepository
    {
        Task<bool> InsertChat(Chats chat);
        Task<bool> DeleteChatById(ChatsById chat);
        Task<IEnumerable<Chats>> GetChatsByUserId(ChatsById chat);
    }
}
