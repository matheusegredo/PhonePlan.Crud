using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PhonePlan.Domain.Context;

namespace PhonePlan.Domain
{
	public static class DependencyInjection
	{
		public static void InjectDomain(this IServiceCollection services)
		{
			services.AddDbContextPool<IApplicationDbContext, ApplicationDbContext>(
				c =>
					c.UseInMemoryDatabase(databaseName: "ApplicationContext")
					);

		}
	}
}
