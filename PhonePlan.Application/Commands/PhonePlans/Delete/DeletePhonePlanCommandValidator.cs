using FluentValidation;

namespace PhonePlan.Application.Commands.PhonePlans.Delete
{
	public sealed class DeletePhonePlanCommandValidator : AbstractValidator<DeletePhonePlanCommand>
	{
		public DeletePhonePlanCommandValidator()
		{
			RuleFor(p => p.PlanCode)
				.NotEmpty();

			RuleFor(p => p.DDD)
				.MaximumLength(3);
		}
	}
}
