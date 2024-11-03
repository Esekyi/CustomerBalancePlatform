using Microsoft.AspNetCore.Mvc;
using CustomerBalancePlatform.Api.Models;
using CustomerBalancePlatform.Api.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CustomerBalancePlatform.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _repository;

        public CustomerController(ICustomerRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers([FromQuery] int page = 1, [FromQuery] int size = 10)
        {
            var customers = await _repository.GetAllCustomersAsync(page, size);
            return Ok(customers);
        }

        [HttpGet("{customerNumber}")]
        public async Task<ActionResult<Customer>> GetCustomer(string customerNumber)
        {
            var customer = await _repository.GetCustomerByNumberAsync(customerNumber);
            if (customer == null) return NotFound();
            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomer(Customer customer)
        {
            var createdCustomer = await _repository.CreateCustomerAsync(customer);
            return CreatedAtAction(nameof(GetCustomer), new { customerNumber = createdCustomer.CustomerNumber }, createdCustomer);
        }

        [HttpPut("{customerNumber}")]
        public async Task<IActionResult> UpdateCustomer(string customerNumber, Customer updatedCustomer)
        {
            var customer = await _repository.UpdateCustomerAsync(customerNumber, updatedCustomer);
            if (customer == null) return NotFound();
            return NoContent();
        }

        [HttpDelete("{customerNumber}")]
        public async Task<IActionResult> DeleteCustomer(string customerNumber)
        {
            var deleted = await _repository.DeleteCustomerAsync(customerNumber);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}