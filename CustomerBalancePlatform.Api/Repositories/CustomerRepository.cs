using CustomerBalancePlatform.Api.Models;
using Microsoft.EntityFrameworkCore;
using CustomerBalancePlatform.Api.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerBalancePlatform.Api.Repositories
{
	public class CustomerRepository : ICustomerRepository
	{
		private readonly CustomerContext _context;

		public CustomerRepository(CustomerContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Customer>> GetAllCustomersAsync(int pageNumber, int pageSize)
		{
			return await _context.Customers!
				.OrderBy(c => c.CustomerNumber)
				.Skip((pageNumber - 1) * pageSize)
				.Take(pageSize)
				.ToListAsync();
		}

		public async Task<Customer?> GetCustomerByNumberAsync(string customerNumber)
		{
			return await _context.Customers!.FirstOrDefaultAsync(c => c.CustomerNumber == customerNumber);
		}

		public async Task<Customer> CreateCustomerAsync(Customer customer)
		{
			_context.Customers!.Add(customer);
			await _context.SaveChangesAsync();
			return customer;
		}

		public async Task<Customer?> UpdateCustomerAsync(string customerNumber, Customer updatedCustomer)
		{
			var customer = await GetCustomerByNumberAsync(customerNumber);
			if (customer == null) return null;

			customer.Name = updatedCustomer.Name;
			customer.Description = updatedCustomer.Description;
			customer.ContactInfo = updatedCustomer.ContactInfo;
			customer.CurrentBalance = updatedCustomer.CurrentBalance;
			customer.LastTransactionDate = updatedCustomer.LastTransactionDate;

			await _context.SaveChangesAsync();
			return customer;
		}

		public async Task<bool> DeleteCustomerAsync(string customerNumber)
		{
			var customer = await GetCustomerByNumberAsync(customerNumber);
			if (customer == null) return false;

			_context.Customers.Remove(customer);
			await _context.SaveChangesAsync();
			return true;
		}
	}
}
