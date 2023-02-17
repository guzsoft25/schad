namespace Ecommerce.Shared.Models.Dtos
{
    public class ProductDto
    {
        public long ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsDeleted { get; set; }
        public string Category { get; set; }
    }
}
