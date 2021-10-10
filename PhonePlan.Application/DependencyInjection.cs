using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PhonePlan.Application.Commands.PhonePlans.Post;

namespace PhonePlan.Application
{
	public static class DependencyInjection
	{
		public static void ApplicationInject(this IServiceCollection services)
		{
			services.AddMediatR(typeof(PostPhonePlanCommand));
		}
	}
}
