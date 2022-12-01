using Dapper;
using MySql.Data.MySqlClient;
using PoointWebApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PoointWebApi.Data.Repositories
{
    public class AvisosRepository : IAvisosRepository
    {
        private MySQLConfiguration _connectionString;
        public AvisosRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<IEnumerable<Avisos>> GetAvisos(Avisos Avisos)
        {
            var db = dbConnection();

            var sql = @"SELECT A.texto, A.fecha, C.username from Avisos A inner JOIN ParticipantesSG B 
                        ON A.id_SubGrupo = B.id_SubGrupo inner JOIN users C ON A.id_user = C.id_user 
                        WHERE A.id_SubGrupo = @id_SubGrupo GROUP BY A.id_Avisos";

            return await db.QueryAsync<Avisos>(sql, new { Avisos.id_SubGrupo });
        }

        public async Task<bool> InsertAviso(Avisos Avisos)
        {
            var db = dbConnection();

            var sql = @" insert into Avisos (id_user,id_SubGrupo,texto,fecha) 
                         value (@id_user,@id_SubGrupo,@texto,CURRENT_TIMESTAMP)";

            var result = await db.ExecuteAsync(sql, new { Avisos.id_user, Avisos.id_SubGrupo, Avisos.texto });

            return result > 0;
        }

        public async Task<bool> UpdateAviso(Avisos Avisos)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAviso(Avisos Avisos)
        {
            throw new NotImplementedException();
        }

        
    }
}
