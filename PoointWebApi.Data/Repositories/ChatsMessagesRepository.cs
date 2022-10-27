using Dapper;
using MySql.Data.MySqlClient;
using PoointWebApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PoointWebApi.Data.Repositories
{
    public class ChatsMessagesRepository: IChatsMessagesRepository
    {
        private MySQLConfiguration _connectionString;
        public ChatsMessagesRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<bool> InsertChatsMessages(ChatMessage chatMessage)
        {
            var db = dbConnection();

            var sql = @"insert into chatsMessages (idChat, message, user) 
                        values (@IdChat, @Message, @User) ";

            var result = await db.ExecuteAsync(sql, new { chatMessage.IdChat, chatMessage.Message, chatMessage.User });

            return result > 0;
        }

        public async Task<IEnumerable<ChatMessageData>> GetChatsById(ChatMessageId chatMessage)
        {
            var db = dbConnection();

            var sql = @"select user, message from chatsmessages where idChat = @IdChat";

            return await db.QueryAsync<ChatMessageData>(sql, new { chatMessage.IdChat});
        }
    }
}
