using BlazorApp1.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace BlazorApp1.Services
{
    public class RouteService : IRouteService
    {
        private readonly HttpClient httpClient;

        public RouteService()
        {
            httpClient = new HttpClient()
            {
                BaseAddress = new Uri("http://127.0.0.1:8000/")
            };
        }

        public async Task<List<Trail>> GetRoutesAsync()
        {
            var response = await httpClient.GetFromJsonAsync<Trail[]>("api/routes");
            var model = response.ToList();
            return model;

        }
        public async Task<bool> DeleteRouteAsync(int nip)
        {
            var response = await httpClient.DeleteAsync($"api/routes/{nip}");
            return response.IsSuccessStatusCode;


        }
        public async Task<Trail> GetRouteAsync(string nip)
        {
            var model = await httpClient.GetFromJsonAsync<Trail>("api/routes/" + nip);
            return model;

        }
        public async Task<bool> UpdateRouteAsync(FormTrail route)
        {
            string jsonString = JsonConvert.SerializeObject(route, new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd" });
            var request = new HttpRequestMessage(HttpMethod.Put, $"api/routes/{route.route_id}");
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
        public async Task<Trail> AddRouteAsync(FormTrail form_route)
        {

            string jsonString = JsonConvert.SerializeObject(form_route, new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd" });

            Console.WriteLine(jsonString);
            var request = new HttpRequestMessage(HttpMethod.Post, "api/routes");
            request.Content = new StringContent(jsonString,
                                                            Encoding.UTF8,
                                                                "application/json");
            request.Headers.Add("Accept", "application/json");
            var response = await httpClient.SendAsync(request);

            var result = response.Content.ReadFromJsonAsync<Trail>().Result;
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

