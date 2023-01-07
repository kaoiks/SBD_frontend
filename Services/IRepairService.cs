using BlazorApp1.Data;

namespace BlazorApp1.Services
{
    public interface IRepairService
    {
        Task<List<Repair>> GetRepairsAsync();

        Task<Repair> GetRepairAsync(string nip);
    }
}
