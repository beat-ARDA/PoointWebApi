using PoointWebApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PoointWebApi.Data.Repositories
{
    public interface IComentarioARepository
    {

        Task<IEnumerable<ComentarioAvi>> GetConentarioIdA(ComentarioAvi ComentarioAvi);

        Task<bool> InsertConentarioA(ComentarioAvi ComentarioAvi);

        Task<bool> UpdateConentarioA(ComentarioAvi ComentarioAvi);

        Task<bool> DeleteConentarioA(ComentarioAvi ComentarioAvi);

    }
}
