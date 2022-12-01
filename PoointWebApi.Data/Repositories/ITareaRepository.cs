using PoointWebApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PoointWebApi.Data.Repositories
{
    public interface ITareaRepository
    {

        Task<IEnumerable<Tarea>> GetTarea(Tarea Tarea);

        Task<bool> InsertTarea(Tarea Tarea);

        Task<bool> UpdateTarea(Tarea Tarea);

        Task<bool> DeleteTarea(Tarea Tarea);
    }
}
