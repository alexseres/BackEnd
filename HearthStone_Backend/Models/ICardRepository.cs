using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HearthStone_Backend.Models
{
    public interface ICardRepository
    {
        Card GetCard(string id);
        IEnumerable<Card> GetCards();
        void AddCards(List<Card> cards);
        void DeleteCard(Card card);

        CardBack GetCardBack(string id);
        IEnumerable<CardBack> GetCardBacks();
        void AddCardBacks(List<CardBack> cardBacks);
        void DeleteCardBack(CardBack cardBacks);

    }
}
