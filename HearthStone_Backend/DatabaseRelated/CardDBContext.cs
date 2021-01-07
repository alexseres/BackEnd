using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HearthStone_Backend.Models
{
    public class CardDBContext : IdentityDbContext<User>
    {
        public CardDBContext(DbContextOptions<CardDBContext> options) : base(options)
        {
        }

        public DbSet<Card> Cards { get; set; }
        public DbSet<CardBack> CardBacks { get; set; } 
        public DbSet<User> Users { get; set; }

        public DbSet<IdentityUserClaim<string>> IdentityUserClaim { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
