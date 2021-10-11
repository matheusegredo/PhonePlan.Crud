using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PhonePlan.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PhonePlan.Domain.Context
{
	public interface IApplicationDbContext
	{
		DbSet<PhonePlansEntity> PhonePlans { get; set; }

		DbSet<DirectRemoteDialingEntity> DirectRemoteDialing { get; set; }

		DbSet<DirectRemoteDialingPhonePlanEntity> DirectRemoteDialingPhonePlan { get; set; }

		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

		ChangeTracker ChangeTracker { get; }
	}
}
