using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerBalancePlatform.Api.Models
{
	public class Customer
	{
		public int Id { get; set; }

		[Key]
		public string CustomerNumber { get; set; }

		[Required]
		public string Name { get; set; }

		public string Description { get; set; }

		[Required]
        public string ContactInfo { get; set; }

		[Required]
		public decimal CurrentBalance { get; set; }

		public DateTime? LastTransactionDate { get; set; }
	}

	public class AuditTrail
    {
        public int Id { get; set; }
        public string EntityName { get; set; }
        public string Action { get; set; }
        public DateTime PerformedAt { get; set; }
    }
	
}