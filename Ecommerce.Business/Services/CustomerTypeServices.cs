using AutoMapper;
using Ecommerce.Shared.Contracts;
using Ecommerce.Shared.Models.Daos;
using Ecommerce.Shared.Models.Dtos;

namespace Ecommerce.Business.Services
{
    public class CustomerTypeServices : ICustomerTypeServices
    {
        private readonly ICustomLogger logger;
        private readonly ICustomerTypeRepository customerTypeRepository;
        private readonly IMapper mapper;

        public CustomerTypeServices(ICustomLogger logger, ICustomerTypeRepository customerTypeRepository, IMapper mapper)
        {
            this.logger = logger;
            this.customerTypeRepository = customerTypeRepository;
            this.mapper = mapper;
        }

        public async Task<bool> CreateCustomerType(CustomerTypeDto customerType, string transaction)
        {
          
            if (string.IsNullOrEmpty(customerType.Description)) {
                logger.Error($"{transaction} - Customer type description is required");
                return false;
            }

            var mapCustomerType = mapper.Map<CustomerTypeDao>(customerType);
            var result = await customerTypeRepository.CreateCustomerType(mapCustomerType, transaction);

            if (!result) {
                logger.Error($"{transaction} - The customer type was not created");
                return false;
            }

            logger.Info($"{transaction} - The customer type was created successfully");
            return true;
        }

        public async Task<bool> DeleteCustomerType(int CustomerTypeId, string transaction)
        {
            bool result = await customerTypeRepository.DeleteCustomerType(CustomerTypeId, transaction);
            return result;
        }

        public async Task<CustomerTypeDto> GetCustomerTypeById(int CustomerTypeId, string transaction)
        {
            var customerType = await customerTypeRepository.GetCustomerTypeById(CustomerTypeId, transaction);
            var mapCustomerType = mapper.Map<CustomerTypeDto>(customerType);
            return mapCustomerType;
        }

        public async Task<IEnumerable<CustomerTypeDto>> GetCustomerTypes(string transaction)
        {
            var customerTypes = await customerTypeRepository.GetAllCustomerTypes(transaction);
            var mapCustomerTypes = mapper.Map<IEnumerable<CustomerTypeDto>>(customerTypes);
            return mapCustomerTypes;
        }

        public async Task<bool> UpdateCustomerType(int CustomerTypeId, CustomerTypeDto customerType, string transaction)
        {
            var mapCustomerType = mapper.Map<CustomerTypeDao>(customerType);

            var updatedResult = await customerTypeRepository.UpdateCustomerType(CustomerTypeId, mapCustomerType, transaction);

            if (updatedResult == null) {
                logger.Error($"{transaction} - It was not possible to modify the customer type");
                return false;
            }

            logger.Info($"{transaction} - The customer type was successfully updated");
            return true;
        }
    }
}
