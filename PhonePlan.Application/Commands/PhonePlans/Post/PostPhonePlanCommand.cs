using MediatR;
using PhonePlan.Domain.Entities;

namespace PhonePlan.Application.Commands.PhonePlans.Post
{
	public class PostPhonePlanCommand : IRequest<int>
	{
		public int Minutes { get; set; }

		public string InternetFranchise { get; set; }

		public decimal Value { get; set; }

		public PlanType PlanType { get; set; }

		public string Operator { get; set; }
	}
}