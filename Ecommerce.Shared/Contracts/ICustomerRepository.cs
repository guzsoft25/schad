using Ecommerce.Shared.Models.Daos;

namespace Ecommerce.Shared.Contracts
{
    public interface ICustomerRepository
    {
        Task<CustomerDao> GetCustomerById(long CustomerId, string transaction);
        Task<IEnumerable<CustomerDao>> GetCustomers(string transaction);
        Task<bool> CreateCustomer(CustomerDao customer, string transaction);

        Task<CustomerDao> UpdateCustomer(long CustomerId, CustomerDao customer, string transaction);

        Task<bool> DeleteCustomer(long CustomerId, string transaction);
    }
}


