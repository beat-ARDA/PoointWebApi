using PoointWebApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PoointWebApi.Data.Repositories
{
    public interface IAvisosRepository
    {
        Task<IEnumerable<Avisos>> GetAvisos(Avisos Avisos);

        Task<bool> InsertAviso(Avisos Avisos);

        Task<bool> UpdateAviso(Avisos Avisos);

        Task<bool> DeleteAviso(Avisos Avisos);

    }
}
