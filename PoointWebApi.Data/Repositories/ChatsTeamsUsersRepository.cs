using MySql.Data.MySqlClient;
using PoointWebApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace PoointWebApi.Data.Repositories
{
    public class ChatsTeamsUsersRepository : IChatsTeamsUsersRepository
    {
        private MySQLConfiguration _connectionString;
        public ChatsTeamsUsersRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<bool> InsertChatTeamUser(ChatsTeamsUsers chatTeamsUser)
        {
            var db = dbConnection();

            var sql = @"insert into chatsteamsusers (userId, chatTeamsId) 
                        values (@UserId, @ChatTeamsId) ";

            var result = await db.ExecuteAsync(sql, new { chatTeamsUser.UserId, chatTeamsUser.ChatTeamsId });

            return result > 0;
        }
    }
}
