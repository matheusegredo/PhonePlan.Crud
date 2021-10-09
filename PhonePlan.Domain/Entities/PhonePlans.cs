namespace PhonePlan.Domain.Entities
{
	public sealed class PhonePlans
	{
		public int PlanCode { get; set; }

		public int Minutes { get; set; }

		public string InternetFranchise { get; set; }

		public decimal Value { get; set; }

		public PlanType PlanType { get; set; }

		public string Operator { get; set; }
	}
}
