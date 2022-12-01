using PoointWebApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PoointWebApi.Data.Repositories
{
    public interface ITareasRepository
    {

        //Task<IEnumerable<Tareas>> GetAllSubGrupos();

        Task<IEnumerable<Tareas>> GetTareasGrupo(Tareas Tareas);

        Task<bool> InsertTareas(Tareas Tareas);

        Task<bool> UpdateTareas(Tareas Tareas);

        Task<bool> DeleteTareas(Tareas Tareas);

    }
}
