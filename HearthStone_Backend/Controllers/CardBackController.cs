using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HearthStone_Backend.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace HearthStone_Backend.Controllers
{
    [Route("cardbackAPI")]
    [ApiController]
    [EnableCors]
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

        [HttpPost("search")]
        public async Task<List<CardBack>> SearchForCard([FromBody] string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return _cardRepository.GetCardBacks().ToList();
            }
            List<CardBack> list = _cardRepository.GetCardBacks().ToList();
            List<CardBack> expectedResults = list.FindAll(x => x.Name.Contains(data));
            return expectedResults;
        }
    }
}
