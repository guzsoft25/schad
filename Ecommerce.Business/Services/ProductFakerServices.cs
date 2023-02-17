using System.Text.Json;

using Ecommerce.Shared.Contracts;
using Ecommerce.Shared.Models.Dtos;

namespace Ecommerce.Business.Services
{
    public class ProductFakerServices : IProductFakerServices
    {
        private readonly IHttpClientFactory httpClientFactory;
        private string productFakerUrl;

      
        public ProductFakerServices(ICustomSettings settings, IHttpClientFactory httpClientFactory)
        {
            productFakerUrl = settings.GetSetting("productFakerUrl");
            this.httpClientFactory = httpClientFactory;

        }


        public async Task<IEnumerable<string>> GetProductFakerCategories()
        {
            var productRoot = await _GetProductFakers();

            if(productRoot == null) {
                return null;
            }

            var Products = productRoot.products.ToList();
            var categoryList = Products.DistinctBy(x => x.category).Select(y => y.category).ToList();
            return categoryList;

        }

        public async Task<IEnumerable<ProductFakerDto>> GetProductFakers()
        {
            var productRoot = await _GetProductFakers();

            if (productRoot == null) {
                return null;
            }

            var Products = productRoot.products.ToList();
            return Products;
        }


        private async Task<ProductFakerRootDto> _GetProductFakers()
        {
            var httpClient = httpClientFactory.CreateClient();

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, productFakerUrl);
            var response = await httpClient.SendAsync(httpRequestMessage);

            if (response.IsSuccessStatusCode) {
                using var contentStream = await response.Content.ReadAsStreamAsync();

                var productRoot = await JsonSerializer.DeserializeAsync
                    <ProductFakerRootDto>(contentStream);

                return productRoot;
            }

            return null;
        }

    }
}
