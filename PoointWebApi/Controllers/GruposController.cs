using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoointWebApi.Data.Repositories;
using System.Threading.Tasks;

namespace PoointWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GruposController : ControllerBase
    {
        private readonly IGrupos _gruposReposytory;

        public GruposController(IGrupos gruposReposytory)
        {
            _gruposReposytory = gruposReposytory;
        }

        [HttpGet]
        [Route("GetAllGrups")]
        public async Task<IActionResult> GetAllCars()
        {
            return Ok(await _gruposReposytory.GetAllGrupos());
        }

    }
}
