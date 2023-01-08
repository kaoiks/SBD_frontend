using BlazorApp1.Data;

namespace BlazorApp1.Services
{
    public interface ISettlementService
    {
        Task<List<Settlement>> GetSettlementsAsync();

        Task<Settlement> GetSettlementAsync(string nip);
    }
}

