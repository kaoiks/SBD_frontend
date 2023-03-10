using BlazorApp1.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Net.Http.Json;
using System.Text;

namespace BlazorApp1.Services
{
    public class ContractorService : IContractorService
    {
        private readonly HttpClient httpClient;

        public ContractorService()
        {
            httpClient = new HttpClient()
            {
                BaseAddress = new Uri("http://127.0.0.1:8000/")
            };
        }

        public async Task<List<Contractor>> GetContractorsAsync()
        {
            var response = await httpClient.GetFromJsonAsync<Contractor[]>("api/contractors");
            var model = response.ToList();
            return model;

        }

        public async Task<Contractor> GetContractorAsync(string nip)
        {
           
            var model = await httpClient.GetFromJsonAsync<Contractor>("api/contractors/" + nip);
            return model;

        }

        public async Task<bool> DeleteContractorAsync(string nip)
        {
            var response=await httpClient.DeleteAsync($"api/contractors/{nip}");
            return response.IsSuccessStatusCode;
            
            
        }

        public async Task<bool> UpdateContractorAsync(FormContractor contractor)
        {
            string jsonString = JsonConvert.SerializeObject(contractor, new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd" });
            var request = new HttpRequestMessage(HttpMethod.Put, $"api/contractors/{contractor.nip}");
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

        public async Task<Contractor> AddContractorAsync(FormContractor form_contractor)
        {
            
            string jsonString = JsonConvert.SerializeObject(form_contractor, new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd" });

            Console.WriteLine(jsonString);
            var request = new HttpRequestMessage(HttpMethod.Post, "api/contractors");
            request.Content = new StringContent(jsonString,
                                                            Encoding.UTF8,
                                                                "application/json");
            request.Headers.Add("Accept", "application/json");
            var response = await httpClient.SendAsync(request);

            var result = response.Content.ReadFromJsonAsync<Contractor>().Result;
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
