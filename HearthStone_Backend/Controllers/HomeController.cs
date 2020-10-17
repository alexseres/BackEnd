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
        public async Task<Dictionary<string, List<Card>>> GetHomePageData()
        {
            var result = await _contextNEW.GetCards();
            return result;
        }
        
        [HttpGet("info")]
        public async Task<Info> GetInfoToHomePage()
        {
            var result = await _contextNEW.GetInfoToHomePage();
            return result;
        }

        [HttpGet("cards-back")]
        public async Task<List<CardsBack>> GetCardsBackData()
        {
            var result = await _contextNEW.GetBackCards();
            return result;
        }
    }
}
