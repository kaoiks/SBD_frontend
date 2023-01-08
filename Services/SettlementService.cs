using BlazorApp1.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace BlazorApp1.Services
{
    public class SettlementService : ISettlementService
    {
        private readonly HttpClient httpClient;

        public SettlementService()
        {
            httpClient = new HttpClient()
            {
                BaseAddress = new Uri("http://127.0.0.1:8000/")
            };
        }

        public async Task<List<Settlement>> GetSettlementsAsync()
        {
            var response = await httpClient.GetFromJsonAsync<Settlement[]>("api/settlements");
            var model = response.ToList();
            return model;

        }

        public async Task<Settlement> GetSettlementAsync(string nip)
        {
            var model = await httpClient.GetFromJsonAsync<Settlement>("api/settlements/" + nip);
            return model;

        }
        public async Task<Settlement> AddSettlementAsync(FormSettlement form_settlement)
        {

            string jsonString = JsonConvert.SerializeObject(form_settlement, new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd" });

            Console.WriteLine(jsonString);
            var request = new HttpRequestMessage(HttpMethod.Post, "api/settlements");
            request.Content = new StringContent(jsonString,
                                                            Encoding.UTF8,
                                                                "application/json");
            request.Headers.Add("Accept", "application/json");
            var response = await httpClient.SendAsync(request);

            var result = response.Content.ReadFromJsonAsync<Settlement>().Result;
            if ((int)response.StatusCode == 201)
            {
                return result;
            }
            else
            {
                return null;
            }

        }
    }


}

