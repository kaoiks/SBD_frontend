using BlazorApp1.Data;

namespace BlazorApp1.Services
{
    public interface IRouteService
    {
        Task<List<Trail>> GetRoutesAsync();

        Task<Trail> GetRouteAsync(string nip);
    }
}

