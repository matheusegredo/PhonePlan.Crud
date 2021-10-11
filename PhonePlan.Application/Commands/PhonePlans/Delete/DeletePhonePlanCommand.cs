using MediatR;

namespace PhonePlan.Application.Commands.PhonePlans.Delete
{
	public sealed class DeletePhonePlanCommand : IRequest<Unit>
	{
		public DeletePhonePlanCommand(int planCode)
		{
			PlanCode = planCode;
		}

		public int PlanCode { get; set; }

		public string DDD { get; set; }
	}
}
