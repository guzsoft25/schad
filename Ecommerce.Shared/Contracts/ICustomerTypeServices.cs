using Ecommerce.Shared.Models.Dtos;

namespace Ecommerce.Shared.Contracts
{
    public interface ICustomerTypeServices
    {
        Task<bool> CreateCustomerType(CustomerTypeDto customerType, string transaction);
        Task<bool> DeleteCustomerType(int CustomerTypeId, string transaction);
        Task<CustomerTypeDto> GetCustomerTypeById(int CustomerTypeId, string transaction);
        Task<IEnumerable<CustomerTypeDto>> GetCustomerTypes(string transaction);
        Task<bool> UpdateCustomerType(int CustomerTypeId, CustomerTypeDto customerType, string transaction);
    }
}
