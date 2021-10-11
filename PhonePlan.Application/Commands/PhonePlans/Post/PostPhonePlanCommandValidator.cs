using FluentValidation;

namespace PhonePlan.Application.Commands.PhonePlans.Post
{
	public class PostPhonePlanCommandValidator : AbstractValidator<PostPhonePlanCommand>
	{
		public PostPhonePlanCommandValidator()
		{
			RuleFor(p => p.PlanCode)
				.NotEmpty()
				.When(p => p.PhonePlanData is null);

			RuleFor(p => p.DDD)
				.NotEmpty()
				.MaximumLength(3);						
		}
	}
}