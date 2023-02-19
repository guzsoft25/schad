namespace Ecommerce.Shared.Models.Dtos
{
    public class InvoiceDto
    {
        public long CustomerId { get; set; }
        public List<InvoiceDetailDto>  Details { get; set; }
    }
}


