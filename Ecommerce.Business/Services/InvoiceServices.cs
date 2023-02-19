using Ecommerce.Shared.Contracts;
using Ecommerce.Shared.Models.Daos;
using Ecommerce.Shared.Models.Dtos;

namespace Ecommerce.Business.Services
{
    public class InvoiceServices : IInvoiceServices
    {
        private readonly ICustomLogger logger;
        private readonly IInvoiceRepository invoiceRepository;
        private readonly ICustomerRepository customerRepository;

        public InvoiceServices(ICustomLogger logger, IInvoiceRepository invoiceRepository,ICustomerRepository customerRepository)
        {
            this.logger = logger;
            this.invoiceRepository = invoiceRepository;
            this.customerRepository = customerRepository;
        }

        public async Task<bool> CreateInvoice(InvoiceDto invoice, string transaction)
        {
            List<InvoiceDetailDao> invoiceDetails = new List<InvoiceDetailDao>();

            try
            {
                if (invoice == null) { 
                    logger.Error($"{transaction} - Invoice is required");
                    return false;
                }

                if (invoice.CustomerId <= 0) { 
                    logger.Error($"{transaction} - CustomerId is required");
                    return false;
                }

                if (invoice.Details == null || invoice.Details.Count == 0) { 
                    logger.Error($"{transaction} - At Least one invoice detail is required");
                    return false;
                }

                var customer = await customerRepository.GetCustomerById(invoice.CustomerId, transaction);

                if (customer == null) {
                    logger.Error($"{transaction} - The customer of id {invoice.CustomerId} does not exist");
                    return false;
                }

                double SubTotalAmount = (double)invoice.Details.Sum(x => x.TotalAmount);
                double TotalItbisAmount = SubTotalAmount * (0.18);
                double TotalAmount = Math.Round((SubTotalAmount + TotalItbisAmount), 2);

                decimal Itbis = (decimal)TotalItbisAmount;
                decimal SubTotal = (decimal)SubTotalAmount;
                decimal Total = (decimal)TotalAmount;
                DateTime InvoiceDate = DateTime.Now;

                //Create invoice Here..
                InvoiceDao finalInvoice = new InvoiceDao {
                    Customer = customer,
                    InvoiceDate = InvoiceDate,
                    Itbis = Itbis,
                    SubTotal = SubTotal,
                    Total = Total
                };

                //Create Invoice details Here..
                foreach (var item in invoice.Details)
                {
                    invoiceDetails.Add(new InvoiceDetailDao
                    {
                        Invoice = finalInvoice,
                        Price = item.Price,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity

                    });
                }

                finalInvoice.InvoiceDetails = invoiceDetails;

                bool creationResult = await invoiceRepository.CreateInvoice(finalInvoice, transaction);

                if (creationResult) {
                    logger.Info($"{transaction} - The invoice was created successfully");
                    return true;
                }
                else {
                    logger.Error($"{transaction} - Not was possible create the invoice");
                    return false;
                }

            }
            catch (Exception ex) {
                logger.Fatal($"{transaction} - {ex.Message}");
                return false;
            }
        }
    }
}
