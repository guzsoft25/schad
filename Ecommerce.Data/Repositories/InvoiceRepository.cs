using Ecommerce.Data.Contexts;
using Ecommerce.Shared.Contracts;
using Ecommerce.Shared.Models.Daos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly ICustomLogger logger;
        private readonly EcommerceDbContext context;

        public InvoiceRepository(ICustomLogger logger, EcommerceDbContext context)
        {
            this.logger = logger;
            this.context = context;
        }

        public async Task<IEnumerable<InvoiceDao>> GetInvoices(DateTime startDate, DateTime endDate, string transaction, long CustomerId = 0)
        {
            IEnumerable<InvoiceDao> invoices = Enumerable.Empty<InvoiceDao>();

            try
            {
                if (CustomerId > 0) {
                    invoices = await context.Invoices
                        .Include(x => x.InvoiceDetails)
                        .Include(x => x.Customer)
                        .Where(x => x.Customer.CustomerId == CustomerId &&
                        (x.InvoiceDate.Date >= startDate.Date && x.InvoiceDate.Date <= endDate)).ToListAsync();
                }
                else {
                    invoices = await context.Invoices
                      .Include(x => x.InvoiceDetails)
                      .Include(x => x.Customer)
                      .Where(x => x.InvoiceDate.Date >= startDate.Date && x.InvoiceDate.Date <= endDate).ToListAsync();
                }
            }
            catch (Exception ex) {
                logger.Fatal($"{transaction} - {ex.Message}");
                return Enumerable.Empty<InvoiceDao>();
            }

            return invoices;
        }

        public async Task<bool> CreateInvoice(InvoiceDao invoice, string transaction)
        {

            await context.Invoices.AddAsync(invoice);

            int result = await context.SaveChangesAsync();

            if (result > 0) {
                logger.Info($"{transaction} - The invoice was created successfully");
                return true;
            }
            else
            {
                logger.Error($"{transaction} - Not was possible create the invoice");
                return false;
            }
        }

    }
}


