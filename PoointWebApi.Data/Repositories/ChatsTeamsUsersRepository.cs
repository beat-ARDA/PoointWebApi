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
        public async Task<bool> InsertChatTeamUser(ChatsTeamsUsers chatTeamUser)
        {
            var db = dbConnection();

            var sql = @"insert into chatsteamsusers (userId, chatTeamsId) 
                        values (@UserId, @ChatTeamsId) ";

            var result = await db.ExecuteAsync(sql, new { chatTeamUser.UserId, chatTeamUser.ChatTeamsId });

            return result > 0;
        }

        public async Task<IEnumerable<ChatsTeamsId>> GetChatsTeamsUserByUserId(ChatsTeamsUsersId chatTeamUser)
        {
            var db = dbConnection();

            var sql = @"select chatTeamsId from chatsteamsusers where userId = @UserId";

            return await db.QueryAsync<ChatsTeamsId>(sql, new { chatTeamUser.UserId });
        }
    }
}
