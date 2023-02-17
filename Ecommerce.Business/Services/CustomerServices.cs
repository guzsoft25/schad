using AutoMapper;
using Ecommerce.Shared.Contracts;
using Ecommerce.Shared.Models.Daos;
using Ecommerce.Shared.Models.Dtos;

namespace Ecommerce.Business.Services
{
    public class CustomerServices: ICustomerServices
    {
        private readonly ICustomLogger logger;
        private readonly ICustomerRepository customerRepository;
        private readonly ICustomerTypeRepository customerTypeRepository;
        private readonly IMapper mapper;

        public CustomerServices(ICustomLogger logger, ICustomerRepository customerRepository, ICustomerTypeRepository customerTypeRepository, IMapper mapper)
        {
            this.logger = logger;
            this.customerRepository = customerRepository;
            this.customerTypeRepository = customerTypeRepository;
            this.mapper = mapper;
        }

        public async Task<bool> CreateCustomer(CustomerDto customer, string transaction)
        {
            if (customer.CustomerTypeId == 0) {
                logger.Error($"{transaction} - CustomerType Id is required");
                return false;
            }

            var customerType = await customerTypeRepository.GetCustomerTypeById(customer.CustomerTypeId, transaction);

            if(customerType == null) {
                logger.Error($"{transaction} - CustomerTypeId {customer.CustomerTypeId} does not exist");
                return false;
            }

            customer.CustomerType = customerType.Description;
            customer.CustomerTypeId = customerType.CustomerTypeId;

            var mapCustomer = mapper.Map<CustomerDao>(customer);
            mapCustomer.CustomerType = customerType;

            var result = await customerRepository.CreateCustomer(mapCustomer, transaction);

            if (!result) {
                logger.Error($"{transaction} - The customer was not created");
                return false;
            }

            logger.Info($"{transaction} - The customer was created successfully");
            return true;
        }

        public async Task<bool> DeleteCustomer(long CustomerId, string transaction)
        {
            bool result = await customerRepository.DeleteCustomer(CustomerId, transaction);
            return result;
        }

        public async Task<CustomerDto> GetCustomerById(long CustomerId, string transaction)
        {
            var customer = await customerRepository.GetCustomerById(CustomerId, transaction);
            var mapCustomer = mapper.Map<CustomerDto>(customer);
            return mapCustomer;
        }

        public async Task<IEnumerable<CustomerDto>> GetCustomers(string transaction)
        {
            var customers = await customerRepository.GetCustomers(transaction);
            var mapCustomers = mapper.Map<IEnumerable<CustomerDto>>(customers);
            return mapCustomers;
        }

        public async Task<bool> UpdateCustomer(long CustomerId, CustomerDto customer, string transaction)
        {
            var mapCustomer = mapper.Map<CustomerDao>(customer);
            
            if (customer.CustomerTypeId > 0) {
                var customerType = await customerTypeRepository.GetCustomerTypeById(customer.CustomerTypeId, transaction);

                if (customerType == null) {
                    logger.Error($"{transaction} - CustomerTypeId {customer.CustomerTypeId} does not exist");
                    return false;
                }

                mapCustomer.CustomerType = customerType;
            }

            var updatedResult = await customerRepository.UpdateCustomer(CustomerId, mapCustomer, transaction);

            if (updatedResult == null) {
                logger.Error($"{transaction} - It was not possible to modify the customer");
                return false;
            }

            logger.Info($"{transaction} - The customer was successfully updated");
            return true;
        }
    }
}
