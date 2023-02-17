using Ecommerce.Shared.Models.Dtos;

namespace Ecommerce.Shared.Contracts
{
    public interface IProductServices
    {
        Task<bool> CreateProductBatchFromFaker(string transaction);
        Task<bool> CreateProductCategoryBatchFromFaker(string transaction);
        Task<IEnumerable<ProductDto>> GetProducts(string transaction);

        Task<ProductDto> GetProductById(long ProductId, string transaction);
    }
}



