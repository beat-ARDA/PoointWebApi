using Dapper;
using MySql.Data.MySqlClient;
using PoointWebApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PoointWebApi.Data.Repositories
{
    public class ParticipantesRepository : IParticipantesRepository
    {
        private MySQLConfiguration _connectionString;
        public ParticipantesRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<Participantes>> GetParticipante(Participantes Participantes)
        {
            var db = dbConnection();

            var sql = @"SELECT * from SubGrupo A Inner JOIN ParticipantesSG B 
                      ON A.id_SubGrupo = B.id_SubGrupo Inner JOIN users C ON B.id_user = C.id_user 
                      WHERE A.id_SubGrupo = @id_SubGrupo";

            return await db.QueryAsync<Participantes>(sql, new { Participantes.id_SubGrupo });
        }

        public async Task<bool> InsertParticipantes(Participantes Participantes)
        {
            var db = dbConnection();

            var sql = @" insert into ParticipantesSG (id_user,id_SubGrupo,nombre,fecha) 
                         value (@id_user,@id_SubGrupo,@nombre,CURRENT_TIMESTAMP)";

            var result = await db.ExecuteAsync(sql, new { Participantes.id_user, Participantes.id_SubGrupo, Participantes.nombre });

            return result > 0;
        }

        public async Task<bool> UpdateParticipantes(Participantes Participantes)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> DeleteParticipantes(Participantes Participantes)
        {
            throw new NotImplementedException();
        }

    }
}
