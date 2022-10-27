using Dapper;
using MySql.Data.MySqlClient;
using PoointWebApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PoointWebApi.Data.Repositories
{
    public class ChatsRepository : IChatsRepository
    {
        private MySQLConfiguration _connectionString;
        public ChatsRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<bool> InsertChat(Chats chat)
        {
            var db = dbConnection();

            var sql = @"insert into chats (userId1, userId2, username1, username2) 
                        values (@Userid1, @Userid2, @Username1, @Username2) ";

            var result = await db.ExecuteAsync(sql, new { chat.UserId1, chat.UserId2, chat.Username1, chat.Username2 });

            return result > 0;
        }
        public async Task<bool> DeleteChatById(ChatsById chat)
        {
            var db = dbConnection();

            var param = new { chat.Id };
            var sql = @"delete from chats where id = @Id";

            var result = await db.ExecuteAsync(sql, param);

            return result > 0;
        }
        public async Task<IEnumerable<Chats>> GetChatsByUserId(ChatsById chat)
        {
            var db = dbConnection();

            var sql = @"select id, userId1, userId2, username1, username2 from chats where userId1 = @Id Or userId2 = @Id";

            return await db.QueryAsync<Chats>(sql, new { chat.Id });
        }
        public async Task<IEnumerable<ChatsIds>> GetChatByIds(ChatsIds chat)
        {
            var db = dbConnection();

            var sql = @"select userId1, userId2 from chats where (userId1 = @UserId1 and userId2 = @UserId2) Or  (userId1 = @UserId2 and userId2 = @UserId1)";

            return await db.QueryAsync<ChatsIds>(sql, new { chat.UserId1, chat.UserId2 });
        }
    }
}
