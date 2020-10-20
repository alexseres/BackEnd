using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HearthStone_Backend.Models;
using Microsoft.AspNetCore.Http;


namespace HearthStone_Backend.Services
{
    public class APIfetcher
    {
        private readonly string urlOfHome = "http://localhost:5000/api/";
        private readonly string urlOfApi = "https://omgvamp-hearthstone-v1.p.rapidapi.com/";
        private readonly string apiHost = "omgvamp-hearthstone-v1.p.rapidapi.com";
        private readonly string apiKey = "dec58908a9msh533ee634def76d9p1385d4jsnb15fc973d01d";
        private Dictionary<string, List<Card>> cardsDictionary;
        private List<Card> cardsList;
        private List<CardBack> cardBackList;
        private Info infoContents;


        public APIfetcher()
        {
            GetInfoToHomePage();
            GetCards();
            GetCardsForSearch();
            GetBackCards();
        }
        
        public List<Card> CardsList
        {
            get => cardsList;
        }

        public List<CardBack> CardBackList
        {
            get => cardBackList;
        }

        public Dictionary<string, List<Card>> CardsDictionary
        {
            get => cardsDictionary;
        
        }

        public Info InfoContents
        {
            get => infoContents;
        }


        public HttpClient BuildsClient(string keyword)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(urlOfHome+keyword);
            client.DefaultRequestHeaders.Add("x-rapidapi-host", apiHost);
            client.DefaultRequestHeaders.Add("x-rapidapi-key", apiKey);
            return client;
        }
        
        
        public async void GetCardsForSearch()
        {
            HttpClient client = BuildsClient("list");
            HttpResponseMessage responseMessage = await client.GetAsync(urlOfApi + "cards");
            if (responseMessage.IsSuccessStatusCode)
            {
                var contentAsString = await responseMessage.Content.ReadAsStringAsync();
                cardsDictionary = JsonConvert.DeserializeObject<Dictionary<string,List<Card>>>(contentAsString);
            }
            cardsList = cardsDictionary.SelectMany(d  => d.Value.Where(card => card.img != null)).ToList();
        }

        public  async void  GetCards()
        {
            HttpClient client = BuildsClient("list");
            HttpResponseMessage responseMessage = await client.GetAsync(urlOfApi + "cards");
            if (responseMessage.IsSuccessStatusCode)
            {
                var contentAsString = await responseMessage.Content.ReadAsStringAsync();
                cardsDictionary = JsonConvert.DeserializeObject<Dictionary<string,List<Card>>>(contentAsString);
            }

        }
        

        public async void GetBackCards()
        {
            HttpClient client = BuildsClient("cards-back");
            HttpResponseMessage response = await client.GetAsync(urlOfApi +"cardbacks");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                cardBackList = JsonConvert.DeserializeObject<List<CardBack>>(content);
            }

        }

        public async void GetInfoToHomePage()
        {
            HttpClient client = BuildsClient("info");
            HttpResponseMessage response = await client.GetAsync(urlOfApi +"info");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                infoContents = JsonConvert.DeserializeObject<Info>(content);
            }

        }
    }
}
