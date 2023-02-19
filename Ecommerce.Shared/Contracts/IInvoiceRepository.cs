using Ecommerce.Shared.Models.Daos;

namespace Ecommerce.Shared.Contracts
{
    public interface IInvoiceRepository
    {
        Task<IEnumerable<InvoiceDao>> GetInvoices(DateTime startDate, DateTime endDate, string transaction, long CustomerId = 0);
        Task<bool> CreateInvoice(InvoiceDao invoice, string transaction);
    }
}
