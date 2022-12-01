using Dapper;
using MySql.Data.MySqlClient;
using PoointWebApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PoointWebApi.Data.Repositories
{
    public class SubGrupoRepository : ISubGruposRepository
    {
        private MySQLConfiguration _connectionString;
        public SubGrupoRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<SubGrupo>> GetAllSubGrupos()
        {
            var db = dbConnection();

            var sql = @" select * from SubGrupo";

            return await db.QueryAsync<SubGrupo>(sql, new { });
        }

        
        public async Task<bool> InsertSubGrupos(SubGrupo subGrupo)
        {
            var db = dbConnection();

            var sql = @"insert into SubGrupo (nombre, fecha,id_Grupo) 
                        value (@nombre,CURRENT_TIMESTAMP,@id_Grupo)";

            var result = await db.ExecuteAsync(sql, new { subGrupo.nombre, subGrupo.id_Grupo });

            return result > 0;
        }

        public async Task<bool> UpdateSubGrupos(SubGrupo subGrupo)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteSubGrupos(SubGrupo subGrupo)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SubGrupo>> GetSubGrupos(SubGrupo SGrupo)
        {
            var db = dbConnection();

            var sql = @"SELECT * from SubGrupo WHERE id_Grupo  = @id_Grupo";

            return await db.QueryAsync<SubGrupo>(sql, new { SGrupo.id_Grupo});

        }

        public async Task<IEnumerable<SubGrupo>> GetSubGruposIDSG(SubGrupo SGrupo)
        {
            var db = dbConnection();

            var sql = @"SELECT * from SubGrupo WHERE id_SubGrupo = @id_SubGrupo";

            return await db.QueryAsync<SubGrupo>(sql, new { SGrupo.id_SubGrupo });
        }
    }
}
