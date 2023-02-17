using Ecommerce.Business.Services;
using Ecommerce.Shared.Contracts;
using Ecommerce.Shared.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices productServices;
        private string transaction;

        public ProductController(IProductServices productServices)
        {
            this.productServices = productServices;
            transaction = Guid.NewGuid().ToString().Substring(0, 10).Replace("-", "").Trim().ToUpper();
        }


        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IActionResult> Get() //IEnumerable<string>
        {
            var Products = await productServices.GetProducts(transaction);

            if(Products == null || Products.Count() == 0) {
                return Ok(Enumerable.Empty<ProductDto>());
            }

            return Ok(Products);

        }

        //// GET api/<ProductController>/5
        [HttpGet("{ProductId}")]
        public async Task<IActionResult> Get(long ProductId)
        {
            var product = await productServices.GetProductById(ProductId, transaction);

            if (product == null) {
                return NotFound(new CustomerDto { });
            }

            return Ok(product);
        }

        //// POST api/<ProductController>
        //[HttpPost]
        //public async Task Post([FromBody] string value)
        //{
        //    var prod = await productServices.CreateProductBatchFromFaker("adsads");
        //}

        //// PUT api/<ProductController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ProductController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
