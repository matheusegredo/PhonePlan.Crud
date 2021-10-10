using MediatR;
using PhonePlan.Domain.Entities;

namespace PhonePlan.Application.Commands.PhonePlans.Put
{
	public class PutPhonePlanCommand : IRequest<Unit>
	{
		public int PlanCode { get; set; }

		public int Minutes { get; set; }

		public string InternetFranchise { get; set; }

		public decimal Value { get; set; }

		public PlanType PlanType { get; set; }
	}
}