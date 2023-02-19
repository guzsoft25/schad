namespace Ecommerce.Shared.Models.Dtos
{
    public class InvoiceDetailDto
    {
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalAmount { get; set; }

        public InvoiceDetailDto()
        {
            TotalAmount = Quantity * Price;
        }
    }
}
