using BlazorApp1.Data;
using Newtonsoft.Json;

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
    }
}
