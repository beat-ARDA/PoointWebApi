using MySql.Data.MySqlClient;
using PoointWebApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace PoointWebApi.Data.Repositories
{
    public class ChatsTeamsRepository : IChatsTeamsRepository
    {
        private MySQLConfiguration _connectionString;
        public ChatsTeamsRepository (MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<bool> InsertChatTeam(ChatsTeams chatTeam)
        {
            var db = dbConnection();

            var sql = @"insert into chatsteams (chatName) 
                        values (@ChatName) ";

            var result = await db.ExecuteAsync(sql, new { chatTeam.ChatName});

            return result > 0;
        }
        public async Task<bool> DeleteChatTeamById(ChatsTeamsById chatTeam)
        {
            var db = dbConnection();

            var param = new { chatTeam.Id };
            var sql = @"delete from chatsteams where id = @Id";

            var result = await db.ExecuteAsync(sql, param);

            return result > 0;
        }
    }
}
