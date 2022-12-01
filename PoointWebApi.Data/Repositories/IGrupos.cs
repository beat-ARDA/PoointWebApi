using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PoointWebApi.Model;

namespace PoointWebApi.Data.Repositories
{
    public interface IGrupos
    {
        Task<IEnumerable<Grupo>> GetAllGrupos();

    }
}
