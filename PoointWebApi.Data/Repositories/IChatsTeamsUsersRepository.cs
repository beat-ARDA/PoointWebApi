using PoointWebApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PoointWebApi.Data.Repositories
{
    public interface IChatsTeamsUsersRepository
    {
        Task<bool> InsertChatTeamUser(ChatsTeamsUsers chatTeam);
    }
}
