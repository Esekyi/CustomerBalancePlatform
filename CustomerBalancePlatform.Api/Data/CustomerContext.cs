using Microsoft.EntityFrameworkCore;
using CustomerBalancePlatform.Api.Models;
using System;

namespace CustomerBalancePlatform.Api.Data
{
	public class CustomerContext : DbContext
	{
		public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
		{
		}

		public DbSet<Customer>? Customers { get; set; }
		public DbSet<AuditTrail>? AuditTrails { get; set; }
	}
}