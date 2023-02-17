using Microsoft.EntityFrameworkCore;

using Ecommerce.Data.Contexts;
using Ecommerce.Shared.Contracts;
using Ecommerce.Shared.Models.Daos;

namespace Ecommerce.Data.Repositories
{
    public class CustomerRepository: ICustomerRepository
    {
        private readonly ICustomLogger logger;
        private readonly EcommerceDbContext context;

        public CustomerRepository(ICustomLogger logger, EcommerceDbContext context)
        {
            this.logger = logger;
            this.context = context;
        }

        public async Task<bool> CreateCustomer(CustomerDao customer,string transaction)
        {
            //Verify if the product already exist (By Name and Category)..
            var currentCustomer = await context.Customers.FirstOrDefaultAsync(x => x.Rnc == customer.Rnc);

            if (currentCustomer != null) {
                logger.Error($"{transaction} - The customer that you try to create already exist");
                return false;
            }

            await context.Customers.AddAsync(customer);
            int result = await context.SaveChangesAsync();

            if (result <= 0) {
                logger.Error($"{transaction} - Not was possible create the customer. Please check the database server connection");
                return false;
            }

            logger.Info($"{transaction} - customer was create successfully!");
            return true;
        }

        public async Task<bool> DeleteCustomer(long CustomerId, string transaction)
        {
            var Customer = await context.Customers.FirstOrDefaultAsync(x => x.CustomerId == CustomerId && x.Status);

            if (Customer == null) {
                logger.Error($"{transaction} - The customer of id {CustomerId} does not exist");
                return false;
            }
            else {
                Customer.Status = false;
                await context.SaveChangesAsync();
                logger.Info($"{transaction} - The customer of id {CustomerId} was successfully deleted");
                return true;
            }
        }

        public async Task<CustomerDao> GetCustomerById(long CustomerId, string transaction)
        {
            var Customer = await context.Customers.Include(x => x.CustomerType).FirstOrDefaultAsync(x => x.CustomerId == CustomerId && x.Status);
            return Customer;
        }

        public async Task<IEnumerable<CustomerDao>> GetCustomers(string transaction)
        {
            var Customers = await context.Customers.Where(x => x.Status).Include(x => x.CustomerType).ToListAsync();
            return Customers;
        }

        public async Task<CustomerDao> UpdateCustomer(long CustomerId, CustomerDao customer, string transaction)
        {
            bool TrackingChanges = false;

            var CurrentCustomer = await context.Customers.FirstOrDefaultAsync(x => x.CustomerId == CustomerId && x.Status);

            if (CurrentCustomer == null) {
                logger.Error($"{transaction} - The Customer of id {CustomerId} does not exist");
                return null;
            }

            if (!string.IsNullOrEmpty(customer.Rnc)) {
                CurrentCustomer.Rnc = customer.Rnc;
                TrackingChanges = true;
            }
            
            if (!string.IsNullOrEmpty(customer.Address)) {
                CurrentCustomer.Address = customer.Address;
                TrackingChanges = true;
            }

            if (!string.IsNullOrEmpty(customer.Address)) {
                CurrentCustomer.Address = customer.Address;
                TrackingChanges = true;
            }

            if (customer.CustomerType != null) {
                CurrentCustomer.CustomerType = customer.CustomerType;
                TrackingChanges = true;
            }

            if (!string.IsNullOrEmpty(customer.Name)) {
                CurrentCustomer.Name = customer.Name;
                TrackingChanges = true;
            }

            if (TrackingChanges) {
               int result = await context.SaveChangesAsync();
               logger.Info($"{transaction} - The customer of Id {CustomerId} was updated successfully");
            }
            else {
                logger.Warn($"{transaction} - No changes detected");
            }

            return CurrentCustomer;
        }
    }
}
