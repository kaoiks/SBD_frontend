using BlazorApp1.Data;
using BlazorApp1.Pages.Drivers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace BlazorApp1.Services
{
    public class DriverService : IDriverService
    {
        private readonly HttpClient httpClient;

        public DriverService()
        {
            httpClient = new HttpClient()
            {
                BaseAddress = new Uri("http://127.0.0.1:8000/")
            };
        }

        public async Task<List<Driver>> GetDriversAsync()
        {
            var response = await httpClient.GetFromJsonAsync<Driver[]>("api/drivers");
            var model = response.ToList();
            return model;

        }

        public async Task<Driver> GetDriverAsync(string nip)
        {
            var model = await httpClient.GetFromJsonAsync<Driver>("api/drivers/" + nip);
            return model;

        }
        public async Task<Driver> AddDriverAsync(FormDriver form_driver)
        {

            string jsonString = JsonConvert.SerializeObject(form_driver, new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd" });

            Console.WriteLine(jsonString);
            var request = new HttpRequestMessage(HttpMethod.Post, "api/drivers");
            request.Content = new StringContent(jsonString,
                                                            Encoding.UTF8,
                                                                "application/json");
            request.Headers.Add("Accept", "application/json");
            var response = await httpClient.SendAsync(request);

            var result = response.Content.ReadFromJsonAsync<Driver>().Result;
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
