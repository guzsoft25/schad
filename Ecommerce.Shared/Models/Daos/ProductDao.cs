namespace Ecommerce.Shared.Models.Daos
{
    public class ProductDao
    {
        public long ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }
        public bool IsDeleted { get; set; }

        public int Stock { get; set; }


        public ProductCategoryDao productCategory { get; set; }
        public ICollection<InvoiceDetailDao> InvoiceDetails { get; set; }

    }
}
