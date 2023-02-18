using Microsoft.EntityFrameworkCore;

using Ecommerce.Data.Contexts;
using Ecommerce.Shared.Contracts;
using Ecommerce.Shared.Models.Daos;

namespace Ecommerce.Data.Repositories
{

    public class CustomerTypeRepository: ICustomerTypeRepository
    {
        private readonly ICustomLogger logger;
        private readonly EcommerceDbContext context;

        public CustomerTypeRepository(ICustomLogger logger, EcommerceDbContext context)
        {
            this.logger = logger;
            this.context = context;
        }

        public async Task<bool> CreateCustomerType(CustomerTypeDao customerType, string transaction)
        {
            //Verify if the product already exist (By Name and Category)..
            var currentCustomerType = await context.CustomerTypes.FirstOrDefaultAsync(x => x.Description.ToUpper() 
            == customerType.Description.ToUpper());

            if (currentCustomerType != null) {
                logger.Error($"{transaction} - The customer type that you try to create already exist");
                return false;
            }

            await context.CustomerTypes.AddAsync(customerType);
            int result = await context.SaveChangesAsync();

            if (result <= 0) {
                logger.Error($"{transaction} - Not was possible create the customer type. Please check the database server connection");
                return false;
            }

            logger.Info($"{transaction} - customer type was create successfully!");
            return true;
        }
        public async Task<IEnumerable<CustomerTypeDao>> GetAllCustomerTypes(string transaction)
        {
            var CustomersTypes = await context.CustomerTypes.Where(x => x.Status).ToListAsync();
            return CustomersTypes;
        }
        public async Task<CustomerTypeDao> GetCustomerTypeById(int CustomerTypeId, string transaction)
        {
            var CustomerType = await context.CustomerTypes.FirstOrDefaultAsync(x => x.CustomerTypeId == CustomerTypeId && x.Status);
            return CustomerType;
        }
        public async Task<CustomerTypeDao> UpdateCustomerType(int CustomerTypeId, CustomerTypeDao customerType, string transaction)
        {
            bool TrackingChanges = false;

            var CurrentCustomerType = await context.CustomerTypes.FirstOrDefaultAsync(x => x.CustomerTypeId == CustomerTypeId && x.Status);

            if (CurrentCustomerType == null) {
                logger.Error($"{transaction} - The Customer Type of id {CustomerTypeId} does not exist");
                return null;
            }

            if (!string.IsNullOrEmpty(customerType.Description)) {
                CurrentCustomerType.Description = customerType.Description;
                TrackingChanges = true;
            }

            if (TrackingChanges) {
                int result = await context.SaveChangesAsync();
                logger.Info($"{transaction} - The customer Type of Id {CustomerTypeId} was updated successfully");
            }
            else {
                logger.Warn($"{transaction} - No changes detected");
            }

            return CurrentCustomerType;
        }
        public async Task<bool> DeleteCustomerType(int CustomerTypeId, string transaction)
        {
            var CustomerType = await context.CustomerTypes.Include(x => x.Customers.Where(x => x.Status)).FirstOrDefaultAsync(x => x.CustomerTypeId == CustomerTypeId && x.Status);

            if (CustomerType == null) {
                logger.Error($"{transaction} - The customer Type of id {CustomerTypeId} does not exist");
                return false;
            }
            else {

                if (CustomerType.Customers != null && CustomerType.Customers.Count > 0) {
                    logger.Error($"{transaction} - Cannot delete this type as it contains customers");
                    return false;
                }

                CustomerType.Status = false;
                await context.SaveChangesAsync();
                logger.Info($"{transaction} - The customer Type of id {CustomerTypeId} was successfully deleted");
                return true;
            }
        }
    }
}


