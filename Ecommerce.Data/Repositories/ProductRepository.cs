using Microsoft.EntityFrameworkCore;
using Ecommerce.Data.Contexts;
using Ecommerce.Shared.Contracts;
using Ecommerce.Shared.Models.Daos;

namespace Ecommerce.Data.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private readonly ICustomLogger logger;
        private readonly EcommerceDbContext context;

        public ProductRepository(ICustomLogger logger, EcommerceDbContext context)
        {
            this.logger = logger;
            this.context = context;
        }

        public async Task<bool> CreateProduct(ProductDao product,string transaction)
        {
            //Verify if the product already exist (By Name and Category)..
            var currentProduct = await context.Products.FirstOrDefaultAsync(x => x.Name.ToUpper()
            == product.Name.ToUpper() && x.productCategory.ProductCategoryId == product.productCategory.ProductCategoryId);

            if (currentProduct != null) {
                logger.Error($"{transaction} - The product that you try to create already exist");
                return false;
            }

            await context.Products.AddAsync(product);
            int result = await context.SaveChangesAsync();

            if(result <= 0) {
                logger.Error($"{transaction} - Not was possible create the product. Please check the database server connection");
                return false;
            }

            logger.Info($"{transaction} - Product was create successfully!");
            return true;
        }

        public async Task<ProductDao> GetProductById(long ProductId, string transaction)
        {
            var Product = await context.Products.Include(x => x.productCategory).FirstOrDefaultAsync(x => x.ProductId == ProductId);
            return Product;
        }

        public async Task<IEnumerable<ProductDao>> GetProducts(string transaction)
        {
            var Products = await context.Products.Include(x => x.productCategory).ToListAsync();
            return Products;
        }

        public async Task DeleteProduct(long ProductId,string transaction)
        {
            var Product = await context.Products.FirstOrDefaultAsync(x => x.ProductId == ProductId);

            if (Product == null) {
                logger.Error($"{transaction} - The product of id {ProductId} does not exist");
            }
            else {
                Product.IsDeleted = true;
                await context.SaveChangesAsync();
                logger.Info($"{transaction} - The product of id {ProductId} was successfully deleted");
            }

        }

        public async Task<IEnumerable<ProductCategoryDao>> GetProductCategories()
        {
            var ProductsCategories = await context.ProductCategories.ToListAsync();
            return ProductsCategories;
        }

        public async Task<bool> CreateProductCategoriesBatch(List<ProductCategoryDao> productCategories,string transaction)
        {
             
            var currentCategories = await context.ProductCategories.ToListAsync();
            var filterCategories = productCategories.Where(item => !currentCategories.Any(item2 => item2.CategoryName == item.CategoryName));

            if (filterCategories == null || filterCategories.Count() == 0) {
                logger.Info($"{transaction} - No new category to add");
                return true;
            }

            await context.ProductCategories.AddRangeAsync(filterCategories);
            await context.SaveChangesAsync();  
            return true;

        }

        public async Task<bool> CreateProductsBatch(List<ProductDao> Products, string transaction)
        {
            var currentProducts = await context.Products.ToListAsync();
            var filterProducts = Products.Where(item => !currentProducts.Any(item2 => item2.Name == item.Name));

            if (filterProducts == null || filterProducts.Count() == 0) {
                logger.Info($"{transaction} - No new products to add");
                return true;
            }

            await context.Products.AddRangeAsync(filterProducts);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
