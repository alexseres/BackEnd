using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HearthStone_Backend.Services
{
    public class APIfetcher
    {
        private readonly string apiHost = "omgvamp-hearthstone-v1.p.rapidapi.com";
        private readonly string apiKey = "dec58908a9msh533ee634def76d9p1385d4jsnb15fc973d01d";


        public async Task<JObject> GetCards()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:5000/api/list");
            client.DefaultRequestHeaders.Add("x-rapidapi-host", apiHost);
            client.DefaultRequestHeaders.Add("x-rapidapi-key", apiKey);

            JObject resultJSON = new JObject();

            HttpResponseMessage responseMessage = await client.GetAsync("https://omgvamp-hearthstone-v1.p.rapidapi.com/cards");

            if (responseMessage.IsSuccessStatusCode)
            {
                string contentAsString = await responseMessage.Content.ReadAsStringAsync();
                JObject contentAsJson = JsonConvert.DeserializeObject<JObject>(contentAsString);
                resultJSON = new JObject(contentAsJson);
            }
            return resultJSON;
        }


        public async Task<List<JObject>> GetBackCards()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:5000/api/cards-back");
            client.DefaultRequestHeaders.Add("x-rapidapi-host", apiHost);
            client.DefaultRequestHeaders.Add("x-rapidapi-key", apiKey);

            List<JObject> resultJSON = new List<JObject>();

            HttpResponseMessage response = await client.GetAsync("https://omgvamp-hearthstone-v1.p.rapidapi.com/cardbacks");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                List<JObject> deserializedContent = JsonConvert.DeserializeObject<List<JObject>>(content);
                resultJSON = new List<JObject>(deserializedContent);
            }
            return resultJSON;
        }

        public async Task<JObject> GetInfoToHomePage()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:5000/api/info");
            client.DefaultRequestHeaders.Add("x-rapidapi-host", apiHost);
            client.DefaultRequestHeaders.Add("x-rapidapi-key", apiKey);

            JObject resultJSON = new JObject();

            HttpResponseMessage response = await client.GetAsync("https://omgvamp-hearthstone-v1.p.rapidapi.com/info");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                JObject deserializedContent = JsonConvert.DeserializeObject<JObject>(content);
                resultJSON = new JObject(deserializedContent);
            }
            return resultJSON;
        }
    }
}
