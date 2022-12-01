using Dapper;
using MySql.Data.MySqlClient;
using PoointWebApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PoointWebApi.Data.Repositories
{
    public class TareaRepository : ITareaRepository
    {
        private MySQLConfiguration _connectionString;
        public TareaRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<Tarea>> GetTarea(Tarea Tarea)
        {
            var db = dbConnection();

            var sql = @"select * from tarea A inner join SubGrupo B 
                      ON A.id_SubGrupo = B.id_SubGrupo Where B.id_SubGrupo = @id_SubGrupo";

            return await db.QueryAsync<Tarea>(sql, new { Tarea.id_SubGrupo });
        }

        public async Task<bool> InsertTarea(Tarea Tarea)
        {
            var db = dbConnection();

            var sql = @"insert into Tarea (Titulo,Descripcion,puntos_max,fecha,estado,id_SubGrupo) 
            value (@Titulo,@Descripcion,10,CURRENT_TIMESTAMP,""Asignado"",@id_SubGrupo)";

            var result = await db.ExecuteAsync(sql, new { Tarea.Titulo, Tarea.Descripcion, Tarea.id_SubGrupo });

            return result > 0;
        }

        public async Task<bool> UpdateTarea(Tarea Tarea)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteTarea(Tarea Tarea)
        {
            throw new NotImplementedException();
        }
    }
}
