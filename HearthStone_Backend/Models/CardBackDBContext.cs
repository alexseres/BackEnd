using Microsoft.EntityFrameworkCore;

namespace HearthStone_Backend.Models
{
    public class CardBackDBContext : DbContext
    {
        public CardBackDBContext(DbContextOptions<CardBackDBContext> options) : base(options)
        {
            
        }
        
        public DbSet<CardBack> CardBacks { get; set; }
    }
}