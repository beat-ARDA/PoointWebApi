using Dapper;
using MySql.Data.MySqlClient;
using PoointWebApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PoointWebApi.Data.Repositories
{
    public class GruposRepository : IGrupos
    {
        private MySQLConfiguration _connectionString;
        public GruposRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<Grupo>> GetAllGrupos()
        {
            var db = dbConnection();

            var sql = @" select * from grupo";

            return await db.QueryAsync<Grupo>(sql, new { });
        }
    }
}
