using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace HearthStone_Backend.Models
{
    public class Card
    {
        public string CardId { get; set; }
        public string Name { get; set; }
        public string CardSet { get; set; }
        public string Type { get; set; }
        public string Faction { get; set; }
        public string Rarity { get; set; }
        public string Cost { get; set; }
        public string Attack { get; set; }
        public string Health { get; set; }
        public string Text { get; set; }
        public string Flavor { get; set; }
        public string Artist { get; set; }
        public bool Collectable { get; set; }
        public bool Elite { get; set; }
        public string Race { get; set; }
        public string img { get; set; }
        public string imgGold { get; set; }
        public string Locale { get; set; }
    }
}
