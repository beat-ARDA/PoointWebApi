using Dapper;
using MySql.Data.MySqlClient;
using PoointWebApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PoointWebApi.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private MySQLConfiguration _connectionString;
        public UserRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<User> GetUserLogin(UserLogIn user)
        {
            var db = dbConnection();

            var param = new { user.Username, user.Password };
            var sql = @"select id_user, username from users where username = @Username and password = @Password";

            return await db.QuerySingleOrDefaultAsync<User>(sql, param);
        }

        public async Task<bool> InsertUser(UserLogIn user)
        {
            var db = dbConnection();

            var sql = @"insert into users (username, password) 
                        values (@Username, @Password) ";

            var result = await db.ExecuteAsync(sql, new { user.Username, user.Password });

            return result > 0;
        }
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var db = dbConnection();

            var sql = @"select id_user, username, estado from users";

            return await db.QueryAsync<User>(sql, new { });
        }

        public async Task<bool> UpdateUserStatus(User user)
        {
            var db = dbConnection();

            var sql = @"UPDATE users SET estado = @estado WHERE id_user = @id_user;"
            ;
            var result = await db.ExecuteAsync(sql, new { user.id_user, user.estado });

            return result > 0;
        }
    }
}
