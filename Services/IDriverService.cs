using BlazorApp1.Data;

namespace BlazorApp1.Services
{
    public interface IDriverService
    {
        Task<List<Driver>> GetDriversAsync();

        Task<Driver> GetDriverAsync(string nip);
    }
}


