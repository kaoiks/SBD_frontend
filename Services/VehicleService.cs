using BlazorApp1.Data;
using Newtonsoft.Json;

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
    }
}
