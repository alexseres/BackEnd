using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HearthStone_Backend.Models;
using HearthStone_Backend.Services;
using Microsoft.AspNetCore.Cors;

namespace HearthStone_Backend.Controllers
{

    [Route("api")]
    [ApiController]
    [EnableCors]
    public class HomeController : ControllerBase
    {
        private readonly APIfetcher _apiFetcher;

        public HomeController(APIfetcher apiFetcher)
        {
            _apiFetcher = apiFetcher;

        }
        
        [HttpGet("info")]
        public async Task<Info> GetInfoToHomePage()
        {
            Info result = await _apiFetcher.GetInfoToHomePage();
            
            return result;
        }

    }
}
