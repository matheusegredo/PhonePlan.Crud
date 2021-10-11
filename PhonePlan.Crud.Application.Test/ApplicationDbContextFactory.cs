using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using PhonePlan.Domain.Context;
using PhonePlan.Domain.Entities;
using System.Collections.Generic;

namespace PhonePlan.Crud.Application.Test
{
	public static class ApplicationDbContextFactory
	{
		public static IApplicationDbContext Create()
		{ 	
			var connection = new SqliteConnection("DataSource=:memory:;");
			connection.Open();

			var builder = new DbContextOptionsBuilder<ApplicationDbContext>()
				.UseSqlite(connection)
				.ConfigureWarnings(x => x.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.AmbientTransactionWarning));

			var context = new ApplicationDbContext(builder.Options);

			var phonePlans = new List<PhonePlansEntity>
			{
				new PhonePlansEntity { PlanCode = 1, Minutes = 100, InternetFranchise = "100GB", Value = 110.99M, PlanType = PlanType.Pos, Operator = "Claro" },
				new PhonePlansEntity { PlanCode = 2, Minutes = 100, InternetFranchise = "100GB", Value = 45.99M, PlanType = PlanType.Pre, Operator = "Claro" },
				new PhonePlansEntity { PlanCode = 3, Minutes = 100, InternetFranchise = "100GB", Value = 90.99M, PlanType = PlanType.Controle, Operator = "Claro" }
			};

			var ddds = new List<DirectRemoteDialingEntity>
			{
				new DirectRemoteDialingEntity { DirectRemoteDialingCode = 1, Code = "019" },
				new DirectRemoteDialingEntity { DirectRemoteDialingCode = 2, Code = "021" },
			};

			context.AddRange(phonePlans);
			context.AddRange(ddds);

			context.SaveChanges();

			var dddsPhonePlans = new List<DirectRemoteDialingPhonePlanEntity>
			{
				new DirectRemoteDialingPhonePlanEntity { DirectRemoteDialingPhonePlanCode = 1, DirectRemoteDialingCode = 1, PhonePlanCode = 1},
				new DirectRemoteDialingPhonePlanEntity { DirectRemoteDialingPhonePlanCode = 2, DirectRemoteDialingCode = 2, PhonePlanCode = 1},
				new DirectRemoteDialingPhonePlanEntity { DirectRemoteDialingPhonePlanCode = 3, DirectRemoteDialingCode = 1, PhonePlanCode = 2},
				new DirectRemoteDialingPhonePlanEntity { DirectRemoteDialingPhonePlanCode = 4, DirectRemoteDialingCode = 2, PhonePlanCode = 2},
				new DirectRemoteDialingPhonePlanEntity { DirectRemoteDialingPhonePlanCode = 5, DirectRemoteDialingCode = 1, PhonePlanCode = 3},
			};

			context.DirectRemoteDialingPhonePlan.AddRange(dddsPhonePlans);
			context.SaveChanges();

			foreach (var dbEntityEntry in context.ChangeTracker.Entries())
			{
				if (dbEntityEntry.Entity is not null)
					dbEntityEntry.State = EntityState.Detached;
			}

			return context;
		}
	}
}
