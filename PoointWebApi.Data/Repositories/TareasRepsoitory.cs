using Dapper;
using MySql.Data.MySqlClient;
using PoointWebApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PoointWebApi.Data.Repositories
{
    public class TareasRepsoitory : ITareasRepository
    {
        private MySQLConfiguration _connectionString;
        public TareasRepsoitory(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<Tareas>> GetTareasGrupo(Tareas Tareas)
        {
            var db = dbConnection();

            var sql = @"SELECT D.Titulo, D.puntos_max , A.fecha, C.username from Tareas A inner JOIN SubGrupo B 
                        ON A.id_SubGrupo = B.id_SubGrupo inner JOIN users C ON C.id_user = A.id_user 
                        inner JOIN tarea D ON A.id_Tarea = D.id_Tarea
                        WHERE B.id_SubGrupo = @id_SubGrupo ";

            return await db.QueryAsync<Tareas>(sql, new { Tareas.id_SubGrupo });
        }

        public async Task<bool> InsertTareas(Tareas Tareas)
        {
            var db = dbConnection();

            var sql = @"insert into Tareas (id_user, id_Tarea,id_SubGrupo,fecha)
                        value (@id_user,@id_Tarea,@id_SubGrupo,CURRENT_TIMESTAMP)";

            var result = await db.ExecuteAsync(sql, new {  Tareas.id_user, Tareas.id_Tarea, Tareas.id_SubGrupo });

            return result > 0;
        }

        public async Task<bool> UpdateTareas(Tareas Tareas)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteTareas(Tareas Tareas)
        {
            throw new NotImplementedException();
        }
    }
}
