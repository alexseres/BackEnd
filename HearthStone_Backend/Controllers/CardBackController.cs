using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HearthStone_Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace HearthStone_Backend.Controllers
{
    [Route("cardbackAPI")]
    [ApiController]
    public class CardBackController : Controller
    {
        private readonly ICardRepository _cardRepository;
        public CardBackController(ICardRepository repository)
        {
            _cardRepository = repository;
        }

        [HttpGet("backs")]
        public async Task<List<CardBack>> GetCardsBackData()
        {
            return _cardRepository.GetCardBacks().ToList();
        }
    }
}
