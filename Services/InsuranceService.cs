using BlazorApp1.Data;
using BlazorApp1.Pages.Insurances;
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
        public async Task<bool> DeleteInsuranceAsync(string nip)
        {
            var response = await httpClient.DeleteAsync($"api/insurances/{nip}");
            return response.IsSuccessStatusCode;


        }
        public async Task<bool> UpdateInsuranceAsync(FormInsurance insurance)
        {
            string jsonString = JsonConvert.SerializeObject(insurance, new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd" });
            var request = new HttpRequestMessage(HttpMethod.Put, $"api/insurances/{insurance.insurance_number}");
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

