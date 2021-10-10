using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PhonePlan.Application.Commands.PhonePlans.Post;
using PhonePlan.Application.Profiles;

namespace PhonePlan.Application
{
	public static class DependencyInjection
	{
		public static void ApplicationInject(this IServiceCollection services)
		{
			services.AddMediatR(typeof(PostPhonePlanCommand));

			services.AddAutoMapper(typeof(PhonePlansProfiles));

			services.AddValidatorsFromAssembly(typeof(PostPhonePlanCommandValidator).Assembly);
		}
	}
}
