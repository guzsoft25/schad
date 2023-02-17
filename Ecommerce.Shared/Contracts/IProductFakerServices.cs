using Ecommerce.Shared.Models.Dtos;

namespace Ecommerce.Shared.Contracts
{
    public interface IProductFakerServices
    {
        Task<IEnumerable<ProductFakerDto>> GetProductFakers();
        Task<IEnumerable<string>> GetProductFakerCategories();
    }
}

