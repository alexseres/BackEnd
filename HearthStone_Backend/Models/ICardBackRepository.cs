using System.Collections;
using System.Collections.Generic;

namespace HearthStone_Backend.Models
{
    public interface ICardBackRepository
    {
        CardBack GetCardBack(string id);
        IEnumerable<CardBack> GetCards();
        void AddCardsBacks(List<CardBack> cardsBacks);
        void DeleteCardBacks(CardBack cardsBack);

    }
}