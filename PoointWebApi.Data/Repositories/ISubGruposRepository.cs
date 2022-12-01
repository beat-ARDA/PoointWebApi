using PoointWebApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PoointWebApi.Data.Repositories
{
    public interface ISubGruposRepository
    {

        Task<IEnumerable<SubGrupo>> GetAllSubGrupos();

        Task<IEnumerable<SubGrupo>> GetSubGrupos(SubGrupo SGrupo);

        Task<IEnumerable<SubGrupo>> GetSubGruposIDSG(SubGrupo SGrupo);

        Task<bool> InsertSubGrupos(SubGrupo subGrupo);

        Task<bool> UpdateSubGrupos(SubGrupo subGrupo);

        Task<bool> DeleteSubGrupos(SubGrupo subGrupo);

    }
}
