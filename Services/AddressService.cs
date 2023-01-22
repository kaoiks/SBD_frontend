using BlazorApp1.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace BlazorApp1.Services
{
    public class AddressService : IAddressService
    {
        private readonly HttpClient httpClient;

        public AddressService()
        {
            httpClient = new HttpClient()
            {
                BaseAddress = new Uri("http://127.0.0.1:8000/")
            };
        }

        public async Task<List<Address>> GetAddressesAsync()
        {
            var response = await httpClient.GetFromJsonAsync<Address[]>("api/addresses");
            var model = response.ToList();
            return model;

        }

        public async Task<Address> GetAddressAsync(int nip)
        {
            var model = await httpClient.GetFromJsonAsync<Address>("api/addresses/" + nip);
            return model;

        }

        public async Task<bool> DeleteAddressAsync(int nip)
        {
            var response = await httpClient.DeleteAsync($"api/addresses/{nip}");
            return response.IsSuccessStatusCode;


        }

        public async Task<bool> UpdateAddressAsync(FormAddress address)
        {
            string jsonString = JsonConvert.SerializeObject(address, new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd" });
            var request = new HttpRequestMessage(HttpMethod.Put, $"api/addresses/{address.id}");
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
        public async Task<Address> AddAddressAsync(FormAddress form_Address)
        {

            string jsonString = JsonConvert.SerializeObject(form_Address, new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd" });

            Console.WriteLine(jsonString);
            var request = new HttpRequestMessage(HttpMethod.Post, "api/addresses");
            request.Content = new StringContent(jsonString,
                                                            Encoding.UTF8,
                                                                "application/json");
            request.Headers.Add("Accept", "application/json");
            var response = await httpClient.SendAsync(request);

            var result = response.Content.ReadFromJsonAsync<Address>().Result;
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
