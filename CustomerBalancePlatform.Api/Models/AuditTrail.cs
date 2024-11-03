using System;

namespace CustomerBalancePlatform.Api.Models
{
	public class AuditTrail
	{
		public int Id { get; set; }
		public string? EntityName { get; set; }
		public string? Action { get; set; }
		public DateTime PerformedAt { get; set; }
	}
}
