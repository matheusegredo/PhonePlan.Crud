using Microsoft.EntityFrameworkCore;
using PhonePlan.Domain.Entities;

namespace PhonePlan.Domain.Context
{
	public interface IApplicationDbContext
	{
		public DbSet<PhonePlans> PhonePlans { get; set; }
	}
}
