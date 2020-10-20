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
using HearthStone_Backend.Migrations;

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
        
        [HttpPost("search")]
        public async Task<List<Card>> GetAskedCardForSearch([FromBody]string data)
        {
            List<Card> list = (List<Card>)_cardRepository.GetCards();
            List<Card> expectedResults = list.FindAll(x => x.Name.Contains(data));
            return expectedResults;
        }

        //If DB is filled succesfully, replace the method with ONLY this: 
        //     return _cardRepository.GetCards().Take(50).ToList();

        [HttpGet("list")]
        public async Task<List<Card>>  GetHomePageData()
        {

            Dictionary<string, List<Card>> apiResult = await _apiFetcher.GetCards();

            foreach (List<Card> list in apiResult.Values)
            {
                _cardRepository.AddCards(list);
            }

            return _cardRepository.GetCards().Take(50).ToList();
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
            List<CardBack> result = await _apiFetcher.GetBackCards();

            _cardRepository.AddCardBacks(result);

            return _cardRepository.GetCardBacks().ToList();
        }
    }
}
