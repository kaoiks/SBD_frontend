using BlazorApp1.Data;

namespace BlazorApp1.Services
{
    public interface IInsuranceService
    {
        Task<List<Insurance>> GetInsurancesAsync();

        Task<Insurance> GetInsuranceAsync(string nip);
    }
}


