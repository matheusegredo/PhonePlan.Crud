using AutoMapper;
using MediatR;
using PhonePlan.Application.Commands.PhonePlans.Put;
using PhonePlan.Application.Profiles;
using PhonePlan.CrossCutting.Exceptions;
using PhonePlan.Domain.Context;
using PhonePlan.Domain.Entities;
using System.Threading.Tasks;
using Xunit;

namespace PhonePlan.Crud.Application.Test.Commands
{
	[Trait("Command", "PhonePlan")]
	public sealed class PutPhonePlanCommandHandlerTest
	{
		private readonly PutPhonePlanCommandHandler _handler;

		public PutPhonePlanCommandHandlerTest()
		{
			var mapper = new MapperConfiguration(cfg => cfg.AddProfile(new PhonePlansProfiles())).CreateMapper();
			var context = ApplicationDbContextFactory.Create();

			_handler = new PutPhonePlanCommandHandler(mapper, context);
		}

		[Fact(DisplayName = "Updating an existing phone plan should return unit")]
		public async Task PutPhonePlanCommandHandler_UpdateAnExistingPhonePlan_ShouldReturnUnit()
		{
			var command = new PutPhonePlanCommand
			{
				PlanCode = 1,
				Minutes = 0,
				InternetFranchise = string.Empty,
				Value = 0.00M,
				PlanType = PlanType.Controle
			};

			var response = await _handler.Handle(command, default);

			Assert.IsType<Unit>(response);
		}

		[Fact(DisplayName = "Updating an nonexisting phone plan should return unit")]
		public async Task PutPhonePlanCommandHandler_UpdateAnNonExistingPhonePlan_ShouldThrowsNotFoundException()
		{
			var command = new PutPhonePlanCommand
			{
				PlanCode = 999,				
			};

			var response = await 

			Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(command, default));
		}
	}
}
