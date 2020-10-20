﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HearthStone_Backend.Models
{
    public class CardDBContext : DbContext
    {
        public CardDBContext(DbContextOptions<CardDBContext> options) : base(options)
        {
        }

        public DbSet<Card> Cards { get; set; }
    }
}