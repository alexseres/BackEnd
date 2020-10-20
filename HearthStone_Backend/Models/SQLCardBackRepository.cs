using System.Collections.Generic;

namespace HearthStone_Backend.Models
{
    public class SQLCardBackRepository: ICardBackRepository
    {
        private readonly CardBackDBContext _context;

        public SQLCardBackRepository(CardBackDBContext context)
        {
            _context = context;
        }
        
        
        public CardBack GetCardBack(string id)
        {
            return _context.CardBacks.Find(id);
        }

        public IEnumerable<CardBack> GetCards()
        {
            return _context.CardBacks;
        }

        public void AddCardsBacks(List<CardBack> cardsBacks)
        {
            foreach (CardBack cardBack in cardsBacks)
            {
                _context.Add(cardBack);
            }

            _context.SaveChanges();
        }

        public void DeleteCardBacks(CardBack cardsBack)
        {
            _context.CardBacks.Remove(cardsBack);
        }
    }
}