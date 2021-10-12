using FluentValidation;

namespace PhonePlan.Application.Commands.PhonePlans.Put
{
	public class PutPhonePlanCommandValidator : AbstractValidator<PutPhonePlanCommand>
	{
		public PutPhonePlanCommandValidator()
		{
			RuleFor(p => p.PlanCode)
				.NotEmpty();

			RuleFor(p => p.PlanType)
				.IsInEnum();
		}		
	}
}