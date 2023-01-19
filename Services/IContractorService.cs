using BlazorApp1.Data;

namespace BlazorApp1.Services
{
    public interface IContractorService
    {
        Task<List<Contractor>> GetContractorsAsync();

        Task<Contractor> GetContractorAsync(string nip);

       // bool IsNIPExist(string nip);
    }
}
