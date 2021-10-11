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

			RuleFor(p => p.PhonePlanData)
				.SetValidator(new PostPhonePlanDataCommandValidator())
				.When(p => p.PhonePlanData is not null);
		}
	}

	public class PostPhonePlanDataCommandValidator : AbstractValidator<PostPhonePlanDataCommand>
	{
		public PostPhonePlanDataCommandValidator()
		{
			RuleFor(p => p.PlanType)
				.IsInEnum();

			RuleFor(p => p.Operator)
				.NotEmpty();				
		}
	}
}