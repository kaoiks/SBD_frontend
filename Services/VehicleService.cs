using BlazorApp1.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace BlazorApp1.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly HttpClient httpClient;

        public VehicleService()
        {
            httpClient = new HttpClient()
            {
                BaseAddress = new Uri("http://127.0.0.1:8000/")
            };
        }

        public async Task<List<Vehicle>> GetVehiclesAsync()
        {
            var response = await httpClient.GetFromJsonAsync<Vehicle[]>("api/vehicles");
            var model = response.ToList();
            return model;

        }

        public async Task<Vehicle> GetVehicleAsync(string nip)
        {
            var model = await httpClient.GetFromJsonAsync<Vehicle>("api/vehicles/" + nip);
            return model;

        }
        public async Task<Vehicle> AddVehicleAsync(FormVehicle form_vehicle)
        {

            string jsonString = JsonConvert.SerializeObject(form_vehicle, new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd" });
            
            Console.WriteLine(jsonString);
            var request = new HttpRequestMessage(HttpMethod.Post, "api/vehicles");
            request.Content = new StringContent(jsonString,
                                                            Encoding.UTF8,
                                                                "application/json");
            request.Headers.Add("Accept", "application/json");
            var response = await httpClient.SendAsync(request);
            
            var result = response.Content.ReadFromJsonAsync<Vehicle>().Result;
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
