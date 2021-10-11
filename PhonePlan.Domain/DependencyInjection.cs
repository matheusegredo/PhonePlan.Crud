using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PhonePlan.Domain.Context;
using Microsoft.Data.Sqlite;

namespace PhonePlan.Domain
{
	public static class DependencyInjection
	{
		public static void DomainInject(this IServiceCollection services)
		{
			var connection = new SqliteConnection("DataSource=:memory:;");
			connection.Open();

			services.AddDbContextPool<IApplicationDbContext, ApplicationDbContext>(
				c =>
					c.UseSqlite(connection)
				);
		}
	}
}
