﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace HearthStone_Backend.Models
{
    public class CardContext : DbContext
    {
        private readonly string apiHost = "omgvamp-hearthstone-v1.p.rapidapi.com";
        private readonly string apiKey = "dec58908a9msh533ee634def76d9p1385d4jsnb15fc973d01d";

        public CardContext(DbContextOptions<CardContext> options)
            : base(options)
        {
        }

        public DbSet<Card> IDK { get; set; }

        public async Task<List<Card>>  GetInfo()
        {
            List<Card> result = new List<Card>();

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:5555/api/list");
            client.DefaultRequestHeaders.Add("x-rapidapi-host", apiHost);
            client.DefaultRequestHeaders.Add("x-rapidapi-key", apiKey);


            HttpResponseMessage responseMessage = await client.GetAsync("https://omgvamp-hearthstone-v1.p.rapidapi.com/cards");

            if (responseMessage.IsSuccessStatusCode)
            {
                Card card = await responseMessage.Content.ReadAsAsync<Card>();
                result.Add(card);
            }

            return result;
        } 
    }
}