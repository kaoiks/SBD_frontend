using BlazorApp1.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace BlazorApp1.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly HttpClient httpClient;

        public InvoiceService()
        {
            httpClient = new HttpClient()
            {
                BaseAddress = new Uri("http://127.0.0.1:8000/")
            };
        }

        public async Task<List<Invoice>> GetInvoicesAsync()
        {
            var response = await httpClient.GetFromJsonAsync<Invoice[]>("api/invoices");
            var model = response.ToList();
            return model;

        }

     

        public async Task<Invoice> GetInvoiceAsync(string nip)
        {
            var model = await httpClient.GetFromJsonAsync<Invoice>("api/invoices/" + nip);
            return model;

        }
        public async Task<Invoice> AddInvoiceAsync(FormInvoice form_invoice)
        {

            string jsonString = JsonConvert.SerializeObject(form_invoice, new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd" });

            Console.WriteLine(jsonString);
            var request = new HttpRequestMessage(HttpMethod.Post, "api/invoices");
            request.Content = new StringContent(jsonString,
                                                            Encoding.UTF8,
                                                                "application/json");
            request.Headers.Add("Accept", "application/json");
            var response = await httpClient.SendAsync(request);

            var result = response.Content.ReadFromJsonAsync<Invoice>().Result;
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

