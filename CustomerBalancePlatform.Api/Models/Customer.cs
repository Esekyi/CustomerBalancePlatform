using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace CustomerBalancePlatform.Api.Models
{
	public class Customer
	{

		[Key]
		public string? CustomerNumber { get; set; }

		[Required]
		public string? Name { get; set; }

		public string? Description { get; set; }

		[Required]
        public string? ContactInfo { get; set; }

		[Required]
		[Column(TypeName = "decimal(18, 2)")]
		public decimal CurrentBalance { get; set; }

		public DateTime? LastTransactionDate { get; set; }
	}
	
}