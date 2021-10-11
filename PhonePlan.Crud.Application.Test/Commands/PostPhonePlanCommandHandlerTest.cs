using AutoMapper;
using MediatR;
using PhonePlan.Application.Commands.PhonePlans.Post;
using PhonePlan.Application.Profiles;
using PhonePlan.CrossCutting.Exceptions;
using PhonePlan.Domain.Entities;
using System.Threading.Tasks;
using Xunit;

namespace PhonePlan.Crud.Application.Test.Commands
{
	[Trait("Command", "PhonePlan")]
	public sealed class PostPhonePlanCommandHandlerTest
	{
		private readonly PostPhonePlanCommandHandler _handler;
		public PostPhonePlanCommandHandlerTest()
		{
			var mapper = new MapperConfiguration(cfg => cfg.AddProfile(new PhonePlansProfiles())).CreateMapper();
			var context = ApplicationDbContextFactory.Create();

			_handler = new PostPhonePlanCommandHandler(mapper, context);
		}

		[Fact(DisplayName = "Add new phone plan should return unit")]
		public async Task PostPhonePlanCommandHandler_WhenAddNewPhonePlanData_ShouldReturnUnit()
		{
			var command = new PostPhonePlanCommand
			{
				DDD = "019",
				PhonePlanData = new PostPhonePlanDataCommand
				{ 
					Minutes = 0,
					InternetFranchise = string.Empty,
					Value = 0.00M,
					PlanType = PlanType.Controle,
					Operator = string.Empty
				}
			};

			var response = await _handler.Handle(command, default);

			Assert.IsType<Unit>(response);
		}

		[Fact(DisplayName = "Add new ddd should return unit")]
		public async Task PostPhonePlanCommandHandler_WhenAddNewDDD_ShouldReturnUnit()
		{
			var command = new PostPhonePlanCommand
			{
				DDD = "011",
				PlanCode = 1
			};

			var response = await _handler.Handle(command, default);

			Assert.IsType<Unit>(response);
		}

		[Fact(DisplayName = "Sending a phone plan who not exists, should throws not found exception")]
		public async Task PostPhonePlanCommandHandler_WhenSendPhonePlanNotExist_ShouldThrowsNotFoundException()
		{
			var command = new PostPhonePlanCommand
			{
				DDD = "011",
				PlanCode = 999
			};			

			await Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(command, default));
		}

		[Fact(DisplayName = "Sending a phone plan who already exist in informed ddd, should throws invalid request exception")]
		public async Task PostPhonePlanCommandHandler_WhenSendPhonePlanWhoExistInInformedDDD_ShouldThrowsInvalidRequestException()
		{
			var command = new PostPhonePlanCommand
			{
				DDD = "019",
				PlanCode = 1
			};

			await Assert.ThrowsAsync<InvalidRequestException>(() => _handler.Handle(command, default));
		}
	}
}
