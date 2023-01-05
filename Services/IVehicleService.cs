using BlazorApp1.Data;

namespace BlazorApp1.Services
{
    public interface IVehicleService
    {
        Task<List<Vehicle>> GetVehiclesAsync();

        Task<Vehicle> GetVehicleAsync(string nip);
    }
}
