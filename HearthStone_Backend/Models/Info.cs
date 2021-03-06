using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


namespace HearthStone_Backend.Models
{
    
    public class Info
    {
        public string Patch { get; set; }
        public List<string> Classes{ get; set; }
        public List<string> Sets{ get; set; }
        public List<string> Standard{ get; set; }
        public List<string> Wild{ get; set; }
        public List<string> Types{ get; set; }
        public List<string> Factions{ get; set; }
        public List<string> Qualities{ get; set; }
        public List<string> Races{ get; set; }
        public List<string> Locales{ get; set; }

    }
}