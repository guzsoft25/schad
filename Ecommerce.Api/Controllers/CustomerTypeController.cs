using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

using Ecommerce.Shared.Contracts;
using Ecommerce.Shared.Models.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerTypeController : ControllerBase
    {
        private readonly ICustomLogger logger;
        private readonly ICustomerTypeServices customerTypeServices;
        private string transaction;

        public CustomerTypeController(ICustomLogger logger, ICustomerTypeServices customerTypeServices)
        {
            this.logger = logger;
            this.customerTypeServices = customerTypeServices;
            transaction = Guid.NewGuid().ToString().Substring(0, 10).Replace("-", "").Trim().ToUpper();
        }



        // GET: api/<CustomerController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var customerTypes = await customerTypeServices.GetCustomerTypes(transaction);

            if (customerTypes == null) {
                return Ok(Enumerable.Empty<CustomerTypeDto>());
            }

            return Ok(customerTypes);
        }

        // GET api/<CustomerController>/5
        [HttpGet("{customerTypeId}")]
        public async Task<IActionResult> Get(int customerTypeId)
        {
            var customerType = await customerTypeServices.GetCustomerTypeById(customerTypeId, transaction);

            if (customerType == null) {
                return NotFound(new CustomerTypeDto { });
            }

            return Ok(customerType);
        }

        // POST api/<CustomerController>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CustomerTypeDto customerType)
        {
            if (customerType == null) {
                logger.Error($"{transaction} - CustomerType is required");
                return BadRequest("CustomerType is required");
            }

            var result = await customerTypeServices.CreateCustomerType(customerType, transaction);

            if (!result) {
                return BadRequest(new ResponseDto { isError = true, Message = "Could not create customer type" });
            }

            return Ok(new ResponseDto { isError = false, Message = "The customer type was created successfully" });
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{customerTypeId}")]
        public async Task<IActionResult> Put(int customerTypeId, [FromBody] CustomerTypeDto customerType)
        {
            if (customerType == null) {
                logger.Error($"{transaction} - customerTypeId is required");
                return BadRequest("customerTypeId is required");
            }

            if (customerTypeId <= 0) {
                logger.Error($"{transaction} - CustomerTypeId is required");
                return BadRequest("CustomerTypeId is required");
            }

            var result = await customerTypeServices.UpdateCustomerType(customerTypeId, customerType, transaction);

            if (!result) {
                return BadRequest(new ResponseDto { isError = true, Message = "Could not updated customer type" });
            }

            return Ok(new ResponseDto { isError = false, Message = "The customer type was updated successfully" });
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{customerTypeId}")]
        public async Task<IActionResult> Delete(int customerTypeId)
        {
            if (customerTypeId <= 0) {
                logger.Error($"{transaction} - customerTypeId is required");
                return BadRequest("customerTypeId is required");
            }

            bool deleteResult = await customerTypeServices.DeleteCustomerType(customerTypeId, transaction);

            if (!deleteResult) {
                return BadRequest(new ResponseDto { isError = true, Message = "Could not delete the customer type" });
            }

            return Ok(new ResponseDto { isError = false, Message = "The customer type was deleted successfully" });
        }
    }
}
