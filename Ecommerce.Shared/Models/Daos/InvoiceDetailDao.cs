namespace Ecommerce.Shared.Models.Daos
{
    public class InvoiceDetailDao
    {
        public long InvoiceDetailId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public long ProductId { get; set; }
        public ProductDao Product { get; set; }
        //public long InvoiceId { get; set; }
        public InvoiceDao  Invoice { get; set; }

    }
}

