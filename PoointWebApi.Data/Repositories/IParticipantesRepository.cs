using PoointWebApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PoointWebApi.Data.Repositories
{
    public interface IParticipantesRepository
    {
       // Task<IEnumerable<Participantes>> GetAllSubGrupos();

        Task<IEnumerable<Participantes>> GetParticipante(Participantes Participantes);

        Task<bool> InsertParticipantes(Participantes Participantes);

        Task<bool> UpdateParticipantes(Participantes Participantes);

        Task<bool> DeleteParticipantes(Participantes Participantes);

    }
}
