using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HearthStone_Backend.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using HearthStone_Backend.Services;

namespace HearthStone_Backend.Controllers
{
    
    [Route("api")]
    [ApiController]
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
