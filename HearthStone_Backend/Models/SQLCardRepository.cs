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

        public CardBack GetCardBack(string id)
        {
            return _context.CardBacks.Find(id);
        }

        public IEnumerable<CardBack> GetCardBacks()
        {
            return _context.CardBacks;
        }

        public void AddCardBacks(List<CardBack> cardBacks)
        {
            foreach (CardBack cardBack in cardBacks)
            {
                _context.Add(cardBack);
            }

            _context.SaveChanges();
        }

        public void DeleteCardBack(CardBack cardBack)
        {
            _context.CardBacks.Remove(cardBack);
        }

        public Info GetInfo(string id)
        {
            return _context.Infos.Find(id);
        }

        public IEnumerable<Info> GetInfos()
        {
            return _context.Infos;
        }

        public void AddInfos(List<Info> infos)
        {
            foreach (Info info in infos)
            {
                _context.Infos.Add(info);
            }

            _context.SaveChanges();
        }

        public void DeleteInfo(Info info)
        {
            _context.Remove(info);
            _context.SaveChanges();
        }

    }
}
