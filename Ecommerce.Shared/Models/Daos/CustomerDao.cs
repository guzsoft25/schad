namespace Ecommerce.Shared.Models.Daos
{
    public class CustomerDao
    {
        public long CustomerId { get; set; }
        public string Rnc { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public bool Status { get; set; }

        //public int CustomerTypeId { get; set; }
        public CustomerTypeDao CustomerType { get; set; }

        public ICollection<InvoiceDao> Invoices { get; set; }

    }
}
