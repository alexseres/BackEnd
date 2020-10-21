using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HearthStone_Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace HearthStone_Backend.Controllers
{
    [Route("cardsAPI")]
    [ApiController]
    public class CardController : ControllerBase
    {

        private readonly ICardRepository _cardRepository;
        private readonly int amountOfCards = 350;
        public CardController(ICardRepository repository)
        {
            _cardRepository = repository;
        }

        [HttpGet("cards")]
        public List<Card> GetCards()
        {
            return _cardRepository.GetCards().Take(amountOfCards).ToList();
        }

        [Route("search")]
        [HttpGet("{query}/{itemNumber}")]
        public async Task<List<Card>> GetAskedCardForSearch([FromQuery(Name ="query" )]string query, [FromQuery(Name="itemNumber")]int itemNumber)
        {
            if (string.IsNullOrEmpty(query))
            {
                return _cardRepository.GetCards().Take(amountOfCards).ToList();
                //return new List<Card>();
            }
            List<Card> list = _cardRepository.GetCards().ToList();
            List<Card> expectedResults = list.FindAll(x => x.Name.Contains(query));
            List<Card> finalResultsWithReduction = expectedResults.Take(itemNumber).ToList();
            return finalResultsWithReduction;
        }

    }
}
