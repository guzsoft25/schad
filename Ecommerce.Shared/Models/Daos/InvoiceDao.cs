namespace Ecommerce.Shared.Models.Daos
{
    public class InvoiceDao
    {
        public long InvoiceId { get; set; }
        public string Ncf { get; set; }
        public decimal Itbis { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public DateTime InvoiceDate { get; set; }

        //public long CustomerId { get; set; }
        public CustomerDao Customer { get; set; }
        public ICollection<InvoiceDetailDao> InvoiceDetails { get; set; }

    }
}


