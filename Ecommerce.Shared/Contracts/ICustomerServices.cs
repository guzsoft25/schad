using Ecommerce.Shared.Models.Dtos;

namespace Ecommerce.Shared.Contracts
{
    public interface ICustomerServices
    {
        Task<IEnumerable<CustomerDto>> GetCustomers(string transaction);
        Task<CustomerDto> GetCustomerById(long CustomerId, string transaction);
        Task<bool> CreateCustomer(CustomerDto customer, string transaction);
        Task<bool> DeleteCustomer(long CustomerId, string transaction);
        Task<bool> UpdateCustomer(long CustomerId,CustomerDto customer, string transaction);
    }
}


