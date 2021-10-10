using FluentValidation;

namespace PhonePlan.Application.Commands.PhonePlans.Post
{
	public class PostPhonePlanCommandValidator : AbstractValidator<PostPhonePlanCommand>
	{
		public PostPhonePlanCommandValidator()
		{
			RuleFor(p => p.DDD)
				.NotEmpty();

			RuleFor(p => p.PlanType)
				.IsInEnum();

			RuleFor(p => p.Operator)
				.NotEmpty();			
		}
	}
}