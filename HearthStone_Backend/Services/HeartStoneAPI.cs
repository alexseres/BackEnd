using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HearthStone_Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace HearthStone_Backend.Services
{
    public class APIfetcher
    {
        private readonly string urlOfHome = "http://localhost:5000/api/";
        private readonly string urlOfApi = "https://omgvamp-hearthstone-v1.p.rapidapi.com/";
        private readonly string apiHost = "omgvamp-hearthstone-v1.p.rapidapi.com";
        private readonly string apiKey = "dec58908a9msh533ee634def76d9p1385d4jsnb15fc973d01d";
        

        private HttpClient BuildsClient(string keyword)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(urlOfHome+keyword);
            client.DefaultRequestHeaders.Add("x-rapidapi-host", apiHost);
            client.DefaultRequestHeaders.Add("x-rapidapi-key", apiKey);
            return client;
        }

        public async Task<List<Card>> GetCards()
        {
            HttpClient client = BuildsClient("list");
            HttpResponseMessage responseMessage = await client.GetAsync(urlOfApi + "cards");
            if (responseMessage.IsSuccessStatusCode)
            {
                var contentAsString = await responseMessage.Content.ReadAsStringAsync();
                Dictionary<string, List<Card>> result = JsonConvert.DeserializeObject<Dictionary<string, List<Card>>>(contentAsString);
                var cardsList = result.SelectMany(d  => d.Value.Where(card => card.img != null)).ToList()
                    .Where(x=> URLExistsChecker.Checker(x.img) == true).ToList();

                return cardsList;
            }
            else
            {
                return new List<Card>();
            }

        }

        public async Task<List<CardBack>> GetBackCards()
        {
            HttpClient client = BuildsClient("cards-back");
            HttpResponseMessage response = await client.GetAsync(urlOfApi +"cardbacks");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                List<CardBack> cardBackList = JsonConvert.DeserializeObject<List<CardBack>>(content);
                cardBackList = cardBackList.Where(x => x.Img != null).ToList()
                    .Where(y => URLExistsChecker.Checker(y.Img) == true).ToList();
                return cardBackList;
            } else
            {
                return null;
            }

        }

        public async Task<Info> GetInfoToHomePage()
        {
            HttpClient client = BuildsClient("info");
            HttpResponseMessage response = await client.GetAsync(urlOfApi +"info");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Info infoContents = JsonConvert.DeserializeObject<Info>(content);

                return infoContents;
            } else
            {
                return null;
            }

        }
    }
}
