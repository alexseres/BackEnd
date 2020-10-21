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
        private readonly ICardRepository _cardRepository;

        public HomeController(ICardRepository repository, APIfetcher apiFetcher)
        {
            _apiFetcher = apiFetcher;
            _cardRepository = repository;

        }
 
        [HttpGet("info")]
        public async Task<Info> GetInfoToHomePage()
        {
            Info result = await _apiFetcher.GetInfoToHomePage();
            
            return result;
        }


        //If DB is filled succesfully, replace the method with ONLY this: 
        //     return _cardRepository.GetCardBacks().ToList();
        [HttpGet("cards-back")]
        public async Task<List<CardBack>> GetCardsBackData()
        {
            return _cardRepository.GetCardBacks().ToList();
        }
    }
}
