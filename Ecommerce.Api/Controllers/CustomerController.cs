using Ecommerce.Shared.Contracts;
using Ecommerce.Shared.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomLogger logger;
        private readonly ICustomerServices customerServices;
        private string transaction;

        public CustomerController(ICustomLogger logger, ICustomerServices customerServices)
        {
            this.logger = logger;
            this.customerServices = customerServices;
            transaction = Guid.NewGuid().ToString().Substring(0, 10).Replace("-", "").Trim().ToUpper();
        }


        // GET: api/<CustomerController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var customers = await customerServices.GetCustomers(transaction);

            if (customers == null) {
                return Ok(Enumerable.Empty<CustomerDto>());
            }

            return Ok(customers);
        }

        // GET api/<CustomerController>/5
        [HttpGet("{customerId}")]
        public async Task<IActionResult> Get(long customerId)
        {
            var customer = await customerServices.GetCustomerById(customerId, transaction);

            if (customer == null) {
                return NotFound(new CustomerDto { });
            }

            return Ok(customer);
        }

        // POST api/<CustomerController>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CustomerDto customer)
        {
            if (customer == null) {
                logger.Error($"{transaction} - Customer is required");
                return BadRequest("Customer is required");
            }

            var result = await customerServices.CreateCustomer(customer, transaction);

            if (!result) {
                return BadRequest(new ResponseDto { isError = true, Message = "Could not create customer" });
            }

            return Ok(new ResponseDto { isError = false, Message = "The customer was created successfully" });
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{customerId}")]
        public async Task<IActionResult> Put(long customerId, [FromBody] CustomerDto customer)
        {
            if (customer == null) {
                logger.Error($"{transaction} - Customer is required");
                return BadRequest("Customer is required");
            }

            if (customerId <= 0) {
                logger.Error($"{transaction} - CustomerId is required");
                return BadRequest("CustomerId is required");
            }

            var result = await customerServices.UpdateCustomer(customerId, customer, transaction);

            if (!result) {
                return BadRequest(new ResponseDto { isError = true, Message = "Could not updated customer" });
            }

            return Ok(new ResponseDto { isError = false, Message = "The customer was updated successfully" });
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{customerId}")]
        public async Task<IActionResult> Delete(long customerId)
        {
            if (customerId <= 0) {
                logger.Error($"{transaction} - CustomerId is required");
                return BadRequest("CustomerId is required");
            }

            bool deleteResult = await customerServices.DeleteCustomer(customerId, transaction);

            if (!deleteResult) {
                return BadRequest(new ResponseDto { isError = true, Message = "Could not delete the customer" });
            }

            return Ok(new ResponseDto { isError = false, Message = "The customer was deleted successfully" });
        }
    }
}
