using BlazorApp1.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace BlazorApp1.Services
{
    public class InsuranceService : IInsuranceService
    {
        private readonly HttpClient httpClient;

        public InsuranceService()
        {
            httpClient = new HttpClient()
            {
                BaseAddress = new Uri("http://127.0.0.1:8000/")
            };
        }

        public async Task<List<Insurance>> GetInsurancesAsync()
        {
            var response = await httpClient.GetFromJsonAsync<Insurance[]>("api/insurances");
            var model = response.ToList();
            return model;

        }

        public async Task<Insurance> GetInsuranceAsync(string nip)
        {
            var model = await httpClient.GetFromJsonAsync<Insurance>("api/insurances/" + nip);
            return model;

        }
        public async Task<Insurance> AddInsuranceAsync(FormInsurance form_insurance)
        {

            string jsonString = JsonConvert.SerializeObject(form_insurance, new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd" });

            Console.WriteLine(jsonString);
            var request = new HttpRequestMessage(HttpMethod.Post, "api/insurances");
            request.Content = new StringContent(jsonString,
                                                            Encoding.UTF8,
                                                                "application/json");
            request.Headers.Add("Accept", "application/json");
            var response = await httpClient.SendAsync(request);

            var result = response.Content.ReadFromJsonAsync<Insurance>().Result;
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

