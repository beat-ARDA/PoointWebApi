using Dapper;
using MySql.Data.MySqlClient;
using PoointWebApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PoointWebApi.Data.Repositories
{
    public class ComentarioARepository : IComentarioARepository
    {
        private MySQLConfiguration _connectionString;
        public ComentarioARepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<ComentarioAvi>> GetConentarioIdA(ComentarioAvi ComentarioAvi)
        {
            var db = dbConnection();

            var sql = @"SELECT * from Comentario_Aviso A Inner JOIN Avisos B 
                        ON A.id_Avisos = B.id_Avisos Inner JOIN users C ON A.id_user = C.id_user 
                        WHERE B.id_Avisos = @id_Avisos GROUP BY A.id_ComentarioA";

            return await db.QueryAsync<ComentarioAvi>(sql, new { ComentarioAvi.id_Avisos });
        }

        public async Task<bool> InsertConentarioA(ComentarioAvi ComentarioAvi)
        {
            var db = dbConnection();

            var sql = @"insert into Comentario_Aviso (id_user,id_Avisos,comentario,fecha) 
                        value (@id_user,@id_Avisos,@comentario,CURRENT_TIMESTAMP)";

            var result = await db.ExecuteAsync(sql, new { ComentarioAvi.id_user, ComentarioAvi.id_Avisos, ComentarioAvi.comentario });

            return result > 0;
        }

        public async Task<bool> UpdateConentarioA(ComentarioAvi ComentarioAvi)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteConentarioA(ComentarioAvi ComentarioAvi)
        {
            throw new NotImplementedException();
        }

    }
}
