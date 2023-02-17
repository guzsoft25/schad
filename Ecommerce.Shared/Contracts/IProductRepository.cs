using Ecommerce.Shared.Models.Daos;

namespace Ecommerce.Shared.Contracts
{
    public interface IProductRepository
    {
        Task<ProductDao> GetProductById(long ProductId,string transaction);
        Task<IEnumerable<ProductDao>> GetProducts(string transaction);
        Task<bool> CreateProduct(ProductDao product,string transaction);
        Task DeleteProduct(long ProductId, string transaction);

        Task<IEnumerable<ProductCategoryDao>> GetProductCategories();

        Task<bool> CreateProductCategoriesBatch(List<ProductCategoryDao> productCategories, string transaction);
        Task<bool> CreateProductsBatch(List<ProductDao> Products, string transaction);
    }
}


