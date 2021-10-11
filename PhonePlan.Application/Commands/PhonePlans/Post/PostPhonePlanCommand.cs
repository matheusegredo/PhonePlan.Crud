using MediatR;
using PhonePlan.Domain.Entities;

namespace PhonePlan.Application.Commands.PhonePlans.Post
{
	public class PostPhonePlanCommand : IRequest<Unit>
	{
		public string DDD { get; set; }

		public int? PlanCode { get; set; }

		public PostPhonePlanDataCommand PhonePlanData { get; set; }
	}

	public class PostPhonePlanDataCommand
	{
		public int Minutes { get; set; }

		public string InternetFranchise { get; set; }

		public decimal Value { get; set; }

		public PlanType PlanType { get; set; }

		public string Operator { get; set; }
	}
}