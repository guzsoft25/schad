using Ecommerce.Shared.Models.Daos;

namespace Ecommerce.Shared.Contracts
{
    public interface ICustomerTypeRepository
    {
        Task<bool> CreateCustomerType(CustomerTypeDao customerType, string transaction);
        Task<CustomerTypeDao> GetCustomerTypeById(int CustomerTypeId, string transaction);
        Task<IEnumerable<CustomerTypeDao>> GetAllCustomerTypes(string transaction);
        Task<CustomerTypeDao> UpdateCustomerType(int CustomerTypeId, CustomerTypeDao customerType, string transaction);
        Task<bool> DeleteCustomerType(int CustomerTypeId, string transaction);
    }
}

