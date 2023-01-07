using BlazorApp1.Data;

namespace BlazorApp1.Services
{
    public interface IInvoiceService
    {
        Task<List<Invoice>> GetInvoicesAsync();

        Task<Invoice> GetInvoiceAsync(string nip);
    }
}

