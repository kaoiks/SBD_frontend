using BlazorApp1.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace BlazorApp1.Services
{
    public class RepairService : IRepairService
    {
        private readonly HttpClient httpClient;

        public RepairService()
        {
            httpClient = new HttpClient()
            {
                BaseAddress = new Uri("http://127.0.0.1:8000/")
            };
        }

        public async Task<List<Repair>> GetRepairsAsync()
        {
            var response = await httpClient.GetFromJsonAsync<Repair[]>("api/repairs");
            var model = response.ToList();
            return model;

        }
        public async Task<bool> DeleteRepairAsync(int nip)
        {
            var response = await httpClient.DeleteAsync($"api/repairs/{nip}");
            return response.IsSuccessStatusCode;


        }
        public async Task<bool> UpdateRepairAsync(FormRepair repair)
        {
            string jsonString = JsonConvert.SerializeObject(repair, new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd" });
            var request = new HttpRequestMessage(HttpMethod.Put, $"api/repairs/{repair.id}");
            request.Content = new StringContent(jsonString,
                                                            Encoding.UTF8,
                                                                "application/json");
            request.Headers.Add("Accept", "application/json");
            var response = await httpClient.SendAsync(request);

            var result = response.Content.ReadAsStringAsync().Result;
            if ((int)response.StatusCode == 200)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
        public async Task<Repair> GetRepairAsync(string nip)
        {
            var model = await httpClient.GetFromJsonAsync<Repair>("api/repairs/" + nip);
            return model;

        }
        public async Task<Repair> AddRepairAsync(FormRepair form_repair)
        {

            string jsonString = JsonConvert.SerializeObject(form_repair, new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd" });

            Console.WriteLine(jsonString);
            var request = new HttpRequestMessage(HttpMethod.Post, "api/repairs");
            request.Content = new StringContent(jsonString,
                                                            Encoding.UTF8,
                                                                "application/json");
            request.Headers.Add("Accept", "application/json");
            var response = await httpClient.SendAsync(request);

            var result = response.Content.ReadFromJsonAsync<Repair>().Result;
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


