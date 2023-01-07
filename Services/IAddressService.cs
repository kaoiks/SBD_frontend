using BlazorApp1.Data;

namespace BlazorApp1.Services
{
    public interface IAddressService
    {
        Task<List<Address>> GetAddressesAsync();

        Task<Address> GetAddressAsync(string nip);
    }
}

