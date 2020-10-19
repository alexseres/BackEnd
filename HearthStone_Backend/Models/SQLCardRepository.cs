using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HearthStone_Backend.Models
{
    public class SQLCardRepository : ICardRepository
    {

        private readonly CardDBContext _context;

        public SQLCardRepository(CardDBContext context)
        {
            _context = context;
        }

        public void AddCards(List<Card> cards)
        {
            foreach(Card card in cards)
            {
                _context.Cards.Add(card);
            }

            _context.SaveChanges();

        }

        public void DeleteCard(Card card)
        {
            _context.Cards.Remove(card);
            _context.SaveChanges();
        }

        public Card GetCard(string id)
        {
            return _context.Cards.Find(id);
        }

        public IEnumerable<Card> GetCards()
        {
            return _context.Cards;
        }
    }
}
