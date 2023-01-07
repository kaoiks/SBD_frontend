﻿using BlazorApp1.Data;

namespace BlazorApp1.Services
{
    public interface IRepairCostService
    {
        Task<List<RepairCost>> GetRepairCostsAsync();
       

        Task<RepairCost> GetRepairCostAsync(string nip);
    }
}

