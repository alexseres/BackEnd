﻿using System;
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

        public void AddUser(User user)
        {
             _context.Users.Add(user);
             _context.SaveChanges();
        }

        public IEnumerable<User> GetUsers(List<User> users)
         {
            return _context.Users;
      
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.Where(x => x.Email.Equals(email)).FirstOrDefault();
        }
    }

}
