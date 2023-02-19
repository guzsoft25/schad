using Ecommerce.Shared.Contracts;
using Ecommerce.Shared.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceServices invoiceServices;

        private readonly ICustomLogger logger;
        private string transaction;

        public InvoiceController(ICustomLogger logger, IInvoiceServices invoiceServices)
        {
            this.logger = logger;
            this.invoiceServices = invoiceServices;
            transaction = Guid.NewGuid().ToString().Substring(0, 10).Replace("-", "").Trim().ToUpper();
        }


        //// GET: api/<InvoiceController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<InvoiceController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<InvoiceController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InvoiceDto invoice)
        {
            if (invoice == null) {
                logger.Error($"{transaction} - Invoice is required");
                return BadRequest("Invoice is required");
            }

            var result = await invoiceServices.CreateInvoice(invoice, transaction);

            if (!result)
            {
                return BadRequest(new ResponseDto { isError = true, Message = "Could not create the invoice" });
            }

            return Ok(new ResponseDto { isError = false, Message = "The invoice was created successfully" });

        }

        //// PUT api/<InvoiceController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<InvoiceController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
