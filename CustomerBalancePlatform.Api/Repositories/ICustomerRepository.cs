using CustomerBalancePlatform.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerBalancePlatform.Api.Repositories
{
	public interface ICustomerRepository
	{
		Task<IEnumerable<Customer>> GetAllCustomersAsync(int pageNumber, int pageSize);
		Task<Customer?> GetCustomerByNumberAsync(string customerNumber);
		Task<Customer?> CreateCustomerAsync(Customer customer);
		Task<Customer?> UpdateCustomerAsync(string customerNumber, Customer updatedCustomer);
		Task<bool> DeleteCustomerAsync(string customerNumber);
	}
}
