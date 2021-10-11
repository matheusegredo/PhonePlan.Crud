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

		public DbSet<DirectRemoteDialingEntity> DirectRemoteDialing { get; set; }

		public DbSet<DirectRemoteDialingPhonePlanEntity> DirectRemoteDialingPhonePlan { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<PhonePlansEntity>()
				.ToTable("PhonePlans")
				.HasKey(p => p.PlanCode);

			modelBuilder.Entity<PhonePlansEntity>()
				.HasMany(p => p.DirectRemoteDialingPhonePlans)
				.WithOne(p => p.PhonePlans)
				.HasForeignKey(p => p.PhonePlanCode);

			modelBuilder.Entity<DirectRemoteDialingEntity>()
				.ToTable("DirectRemoteDialing")
				.HasKey(p => p.DirectRemoteDialingCode);

			modelBuilder.Entity<DirectRemoteDialingEntity>()
				.HasMany(p => p.DirectRemoteDialingPhonePlans)
				.WithOne(p => p.DirectRemoteDialing)
				.HasForeignKey(p => p.DirectRemoteDialingCode);

			modelBuilder.Entity<DirectRemoteDialingPhonePlanEntity>()
				.ToTable("DirectRemoteDialingPhonePlan")
				.HasKey(p => p.DirectRemoteDialingPhonePlanCode);

			//modelBuilder.Entity<DirectRemoteDialingPhonePlanEntity>()
			//	.HasOne(p => p.DirectRemoteDialing)
			//	.WithMany();

			//modelBuilder.Entity<DirectRemoteDialingPhonePlanEntity>()
			//	.HasOne(p => p.PhonePlans)
			//	.WithMany();
		}
	}
}
