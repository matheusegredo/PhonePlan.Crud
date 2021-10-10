namespace PhonePlan.Domain.Entities
{
	public sealed class PhonePlansEntity
	{
		public int PlanCode { get; set; }

		public string DDD { get; set; }

		public int Minutes { get; set; }

		public string InternetFranchise { get; set; }

		public decimal Value { get; set; }

		public PlanType PlanType { get; set; }

		public string Operator { get; set; }
	}
}
