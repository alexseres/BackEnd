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
        public async Task<List<Card>> GetCards()
        {
            return _cardRepository.GetCards().Take(amountOfCards).ToList();
        }

        [HttpPost("search")]
        public async Task<List<Card>> SearchForCard([FromBody] string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return _cardRepository.GetCards().Take(amountOfCards).ToList();
            }
            List<Card> list = _cardRepository.GetCards().ToList();
            List<Card> expectedResults = list.FindAll(x => x.Name.Contains(data));
            return expectedResults;
        }

    }
}
