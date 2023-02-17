namespace Ecommerce.Shared.Models.Daos
{
    public class ProductCategoryDao
    {
        public int ProductCategoryId { get; set; }
        public string CategoryName { get; set; }
        public ICollection<ProductDao> Products { get; set; }
    }
}

