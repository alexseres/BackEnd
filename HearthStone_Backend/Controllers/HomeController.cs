﻿using System;
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
        
        [HttpPost("search")]
        public async Task<List<Card>> GetAskedCardForSearch([FromBody]string data)
        {
            List<Card> list = _contextNEW.CardsList;
            List<Card> expectedResults = list.FindAll(x => x.Name.Contains(data));
            return expectedResults;
        }
        
        
        [HttpGet("list")]
        public async Task<Dictionary<string, List<Card>>> GetHomePageData()
        {
            var result = _contextNEW.CardsDictionary;
            return result;
        }
        
        [HttpGet("info")]
        public async Task<Info> GetInfoToHomePage()
        {

            var result =  _contextNEW.InfoContents;
            return result;
        }

        [HttpGet("cards-back")]
        public async Task<List<CardsBack>> GetCardsBackData()
        {
            var result = _contextNEW.CardsBackList;
            return result;
        }
    }
}
