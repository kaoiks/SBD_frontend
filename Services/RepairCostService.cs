﻿using BlazorApp1.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace BlazorApp1.Services
{
    public class RepairCostService : IRepairCostService
    {
        private readonly HttpClient httpClient;

        public RepairCostService()
        {
            httpClient = new HttpClient()
            {
                BaseAddress = new Uri("http://127.0.0.1:8000/")
            };
        }

        public async Task<List<RepairCost>> GetRepairCostsAsync()
        {
            var response = await httpClient.GetFromJsonAsync<RepairCost[]>("api/costs");
            var model = response.ToList();
            return model;

        }

        public async Task<RepairCost> GetRepairCostAsync(string nip)
        {
            var model = await httpClient.GetFromJsonAsync<RepairCost>("api/costs/" + nip);
            return model;

        }
        public async Task<List<RepairCost>> GetRepairCostsByRepairAsync(string nip)
        {
            var response = await httpClient.GetFromJsonAsync<RepairCost[]>("api/costs/?repair=" +nip);
            var model = response.ToList();
            return model;

        }
        public async Task<RepairCost> AddRepairCostAsync(FormRepairCost form_repairCost)
        {

            string jsonString = JsonConvert.SerializeObject(form_repairCost, new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd" });

            Console.WriteLine(jsonString);
            var request = new HttpRequestMessage(HttpMethod.Post, "api/costs");
            request.Content = new StringContent(jsonString,
                                                            Encoding.UTF8,
                                                                "application/json");
            request.Headers.Add("Accept", "application/json");
            var response = await httpClient.SendAsync(request);

            var result = response.Content.ReadFromJsonAsync<RepairCost>().Result;
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

