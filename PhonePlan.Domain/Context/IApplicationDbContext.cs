using Microsoft.EntityFrameworkCore;
using PhonePlan.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PhonePlan.Domain.Context
{
	public interface IApplicationDbContext
	{
		public DbSet<PhonePlansEntity> PhonePlans { get; set; }

		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
	}
}
