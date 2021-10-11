using FluentValidation;

namespace PhonePlan.Application.Queries.PhonePlans.Search
{
	public class SearchPhonePlansQueryValidator : AbstractValidator<SearchPhonePlansQuery>
	{
		public SearchPhonePlansQueryValidator()
		{
			RuleFor(p => p.DDD)
				.NotEmpty()
				.MaximumLength(3);
		}
	}
}