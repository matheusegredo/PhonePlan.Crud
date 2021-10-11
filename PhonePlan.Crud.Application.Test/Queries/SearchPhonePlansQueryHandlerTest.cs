using AutoMapper;
using PhonePlan.Application.Profiles;
using PhonePlan.Application.Queries.PhonePlans.Search;
using PhonePlan.Domain.Context;
using PhonePlan.Domain.Entities;
using System.Threading.Tasks;
using Xunit;

namespace PhonePlan.Crud.Application.Test.Queries
{
	[Trait("Command", "PhonePlan")]
	public sealed class SearchPhonePlansQueryHandlerTest
	{
		private readonly SearchPhonePlansQueryHandler _handler;

		public SearchPhonePlansQueryHandlerTest()
		{
			var mapper = new MapperConfiguration(cfg => cfg.AddProfile(new PhonePlansProfiles())).CreateMapper();
			var context = ApplicationDbContextFactory.Create();

			_handler = new SearchPhonePlansQueryHandler(mapper, context);
		}

		[Fact(DisplayName = "Searching an existing DDD, should return list")]
		public async Task SearchPhonePlansQueryHandler_SearchingExistingDDD_ShouldReturnList()
		{
			var command = new SearchPhonePlansQuery
			{
				DDD = "019"				
			};

			var response = await _handler.Handle(command, default);

			Assert.NotEmpty(response);
		}

		[Fact(DisplayName = "Searching an nonexisting DDD, should return empty list")]
		public async Task SearchPhonePlansQueryHandler_SearchingNonExistingDDD_ShouldReturnEmptyList()
		{
			var command = new SearchPhonePlansQuery
			{
				DDD = "000"
			};

			var response = await _handler.Handle(command, default);

			Assert.Empty(response);
		}

		[Fact(DisplayName = "Searching an existing DDD with an phone plan not available, should return an empty list")]
		public async Task SearchPhonePlansQueryHandler_SearchingExistingDDDWithNotAvaiblePhonePlan_ShouldReturnEmptyList()
		{
			var command = new SearchPhonePlansQuery
			{
				DDD = "019",
				PlanCode = 999
			};

			var response = await _handler.Handle(command, default);

			Assert.Empty(response);
		}

		[Fact(DisplayName = "Searching an existing DDD with an avaible operator, should return an list")]
		public async Task SearchPhonePlansQueryHandler_SearchingExistingDDDWithAvaibleOperator_ShouldReturnList()
		{
			var command = new SearchPhonePlansQuery
			{
				DDD = "019",
				Operator = "Claro"
			};

			var response = await _handler.Handle(command, default);

			Assert.NotEmpty(response);
		}

		[Fact(DisplayName = "Searching an existing DDD with an operator not available, should return an empty list")]
		public async Task SearchPhonePlansQueryHandler_SearchingExistingDDDWithNotAvaibleOperator_ShouldReturnEmptyList()
		{
			var command = new SearchPhonePlansQuery
			{
				DDD = "019",
				Operator = "Vivo"
			};

			var response = await _handler.Handle(command, default);

			Assert.Empty(response);
		}

		[Fact(DisplayName = "Searching an existing DDD with an plan type available, should return an list")]
		public async Task SearchPhonePlansQueryHandler_SearchingExistingDDDWithAvaiblePlanType_ShouldReturnList()
		{
			var command = new SearchPhonePlansQuery
			{
				DDD = "019",
				PlanType = PlanType.Pos
			};

			var response = await _handler.Handle(command, default);

			Assert.NotEmpty(response);
		}

		[Fact(DisplayName = "Searching an existing DDD with an plan type nonavailable, should return an empty list")]
		public async Task SearchPhonePlansQueryHandler_SearchingExistingDDDWithNonAvaiblePlanType_ShouldReturnEmptyList()
		{
			var command = new SearchPhonePlansQuery
			{
				DDD = "019",
				PlanType = PlanType.Controle
			};

			var response = await _handler.Handle(command, default);

			Assert.Empty(response);
		}

		[Fact(DisplayName = "Searching with all avaible filters, should return list with one phone plan")]
		public async Task SearchPhonePlansQueryHandler_SearchingWithAllAvaibleFilters_ShouldReturnOneRegister()
		{
			var command = new SearchPhonePlansQuery
			{
				DDD = "019",
				PlanCode = 1,
				PlanType = PlanType.Pos,
				Operator = "Claro"				
			};

			var response = await _handler.Handle(command, default);

			Assert.True(response.Count == 1);
		}
	}
}
