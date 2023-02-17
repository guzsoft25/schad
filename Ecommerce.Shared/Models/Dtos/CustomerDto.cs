namespace Ecommerce.Shared.Models.Dtos
{
    public class CustomerDto
    {
        public long CustomerId { get; set; }
        public string? Rnc { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public bool Status { get; set; }
        public string? CustomerType { get; set; }
        public int CustomerTypeId { get; set; }
    }
}
