using Microsoft.EntityFrameworkCore;
using PhonePlan.Domain.Entities;

namespace PhonePlan.Domain.Context
{
	public sealed class ApplicationDbContext : DbContext, IApplicationDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
			Database.EnsureCreated();
		}

		public DbSet<PhonePlansEntity> PhonePlans { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<PhonePlansEntity>()
				.HasKey(p => p.PlanCode);
		}
	}
}
