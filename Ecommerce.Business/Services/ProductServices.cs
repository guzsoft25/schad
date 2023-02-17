using AutoMapper;
using Ecommerce.Shared.Contracts;
using Ecommerce.Shared.Models.Daos;
using Ecommerce.Shared.Models.Dtos;

namespace Ecommerce.Business.Services
{
    public class ProductServices: IProductServices
    {
        private readonly ICustomLogger logger;
        private readonly IProductRepository productRepository;
        private readonly IProductFakerServices productFakerServices;
        private readonly IMapper mapper;

        public ProductServices(ICustomLogger logger, IProductRepository productRepository, 
            IProductFakerServices productFakerServices, IMapper mapper)
        {
            this.logger = logger;
            this.productRepository = productRepository;
            this.productFakerServices = productFakerServices;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetProducts(string transaction)
        {
            var products = await productRepository.GetProducts(transaction);

            var mapProducts = mapper.Map<IEnumerable<ProductDto>>(products);
            return mapProducts;
        }

        public async Task<ProductDto> GetProductById(long ProductId, string transaction)
        {
            var product = await productRepository.GetProductById(ProductId, transaction);
            var mapProduct = mapper.Map<ProductDto>(product);
            return mapProduct;
        }

        public async Task<bool> CreateProductBatchFromFaker(string transaction)
        {
            List<ProductDao> products = new List<ProductDao>();

            var fakerProducts = await productFakerServices.GetProductFakers();

            if(fakerProducts == null || fakerProducts.Count() == 0) {
                logger.Warn($"{transaction} - No faker product found");
                return false;
            }

            var productCategories = await productRepository.GetProductCategories();

            if (productCategories == null || productCategories.Count() == 0) {
                logger.Warn($"{transaction} - No product categories found");
                return false;
            }

            foreach (var product in fakerProducts) {
               
                string productName = product.title;
                string productDescription = product.description;
                decimal productPrice = decimal.Parse(product.price.ToString());
                string imageUrl = product.images.FirstOrDefault();
                int Stock = product.stock;

                var productCategory = productCategories.FirstOrDefault(x => x.CategoryName == product.category);

                if(productCategory == null) {
                    logger.Error($"{transaction} - Product {product.title} is not allowed because its category ({product.category}) does not exist");
                    continue;
                }

                int productCategoryId = productCategory.ProductCategoryId;

                products.Add(new ProductDao {
                    Name = productName,
                    productCategory = productCategory,
                    Description = productDescription,
                    ImageUrl = imageUrl,
                    IsDeleted = false,
                    Price = productPrice,
                    Stock = Stock
                });

            }

            bool isSuccess = await productRepository.CreateProductsBatch(products, transaction);
            return isSuccess;
        }
        public async Task<bool> CreateProductCategoryBatchFromFaker(string transaction)
        {
            List<ProductCategoryDao> productCategories = new List<ProductCategoryDao>();

            var fakerCategories = await productFakerServices.GetProductFakerCategories();

            if(fakerCategories == null || fakerCategories.Count() == 0) {
                logger.Error($"{transaction} - No faker categories found");
                return false;
            }

            foreach (var category in fakerCategories) {
                productCategories.Add(new ProductCategoryDao {
                     CategoryName = category
                });
            }


            bool isSuccess = await productRepository.CreateProductCategoriesBatch(productCategories, transaction);
            return isSuccess;
        }
    }
}
