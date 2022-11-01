using PoointWebApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PoointWebApi.Data.Repositories
{
    public interface IChatsTeamsRepository
    {
        Task<bool> InsertChatTeam(ChatsTeams chatTeam);
        Task<bool> DeleteChatTeamById(ChatsTeamsById chatTeam);
        Task<ChatsTeamsById> GetChatTeamId(ChatsTeams chatTeam);
        Task<ChatsTeamsData> GetChatTeamById(ChatsTeamsById chatTeam);
    }
}
