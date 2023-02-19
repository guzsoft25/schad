using Ecommerce.Shared.Models.Dtos;

namespace Ecommerce.Shared.Contracts
{
    public interface IInvoiceServices
    {
        Task<bool> CreateInvoice(InvoiceDto invoice, string transaction);
    }
}
