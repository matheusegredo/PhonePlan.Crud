namespace PhonePlan.Application.Queries.PhonePlans.Search
{
	public sealed class SearchPhonePlansQueryResponse
	{
		public int PlanCode { get; set; }

		public int Minutes { get; set; }

		public string InternetFranchise { get; set; }

		public decimal Value { get; set; }

		public string PlanType { get; set; }

		public string Operator { get; set; }
	}
}