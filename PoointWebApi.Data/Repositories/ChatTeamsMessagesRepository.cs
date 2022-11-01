using MySql.Data.MySqlClient;
using PoointWebApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace PoointWebApi.Data.Repositories
{
    public class ChatTeamsMessagesRepository : IChatTeamsMessagesRepository
    {
        private MySQLConfiguration _connectionString;
        public ChatTeamsMessagesRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<bool> InsertChatTeamsMessages(ChatTeamsMessages chatTeamsMessage)
        {
            var db = dbConnection();

            var sql = @"insert into chatsteamsmessages (idChatTeam, message, user) 
                        values (@IdChatTeam, @Message, @User) ";

            var result = await db.ExecuteAsync(sql, new { chatTeamsMessage.IdChatTeam, chatTeamsMessage.Message, chatTeamsMessage.User });

            return result > 0;
        }

        public async Task<IEnumerable<ChatTeamsMessagesData>> GetChatsTeamsById(ChatTeamsMessagesId chatTeamMessage)
        {
            var db = dbConnection();

            var sql = @"select user, message from chatsteamsmessages where idChatTeam = @IdChatTeam";

            return await db.QueryAsync<ChatTeamsMessagesData>(sql, new { chatTeamMessage.IdChatTeam });
        }
    }
}
