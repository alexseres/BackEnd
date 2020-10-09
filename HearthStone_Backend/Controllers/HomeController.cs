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
        private readonly ILogger<HomeController> _logger;
        private readonly APIfetcher _contextNEW;

        public HomeController(ILogger<HomeController> logger, APIfetcher apiFetcher)
        {
            _logger = logger;
            _contextNEW = apiFetcher;
        }
        
        [HttpGet("list")]
        public async Task<JObject> GetHomePageData()
        {
            JObject result = await _contextNEW.GetCards();

            return result;
        }
        
        [HttpGet("info")]
        public async Task<JObject> GetInfoToHomePage()
        {
            JObject result = await _contextNEW.GetInfoToHomePage();

            return result;
        }

        [HttpGet("cards-back")]
        public async Task<List<JObject>> GetCardsBackData()
        {
            List<JObject> result = await _contextNEW.GetBackCards();
            return result;
        }
    }
}
