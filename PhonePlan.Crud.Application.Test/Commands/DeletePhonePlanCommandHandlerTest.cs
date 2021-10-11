using PhonePlan.Application.Commands.PhonePlans.Delete;
using PhonePlan.CrossCutting.Exceptions;
using PhonePlan.Domain.Context;
using System.Threading.Tasks;
using Xunit;

namespace PhonePlan.Crud.Application.Test.Commands
{
	[Trait("Command", "PhonePlan")]
	public sealed class DeletePhonePlanCommandHandlerTest
	{
		private readonly DeletePhonePlanCommandHandler _handler;
		private readonly IApplicationDbContext _context;

		public DeletePhonePlanCommandHandlerTest()
		{
			_context = ApplicationDbContextFactory.Create();
			_handler = new DeletePhonePlanCommandHandler(_context);
		}

		[Fact(DisplayName = "When pass plan code and ddd, should delete the relationship")]
		public async Task DeletePhonePlanCommandHandler_WhenPassPlanCodeAndDDD_ShouldDeleteRelationship()
		{
			var command = new DeletePhonePlanCommand
			{				
				PlanCode = 1,
				DDD = "019"
			};

			await _handler.Handle(command, default);

			var phonePlanStillExisting = await _context.PhonePlans.FindAsync(command.PlanCode);

			Assert.True(phonePlanStillExisting is not null);
		}

		[Fact(DisplayName = "When pass only plan code, should delete the phone plan")]
		public async Task DeletePhonePlanCommandHandler_WhenPassPlan_ShouldDeletePhonePlan()
		{
			var command = new DeletePhonePlanCommand
			{
				PlanCode = 1
			};

			await _handler.Handle(command, default);

			var deletedPhonePlan = await _context.PhonePlans.FindAsync(command.PlanCode);

			Assert.True(deletedPhonePlan is null);
		}

		[Fact(DisplayName = "When pass an ddd that doesn't exist, should throws not found exception")]
		public async Task DeletePhonePlanCommandHandler_WhenDDDNotExist_ShouldThrowsNotFoundException()
		{
			var command = new DeletePhonePlanCommand
			{
				PlanCode = 1,
				DDD = "999"
			};			

			await Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(command, default));
		}

		[Fact(DisplayName = "When pass an plan code that doesn't exist, should throws not found exception")]
		public async Task DeletePhonePlanCommandHandler_WhenPhonePlanNotExist_ShouldThrowsNotFoundException()
		{
			var command = new DeletePhonePlanCommand
			{
				PlanCode = 999
			};

			await Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(command, default));
		}
	}
}
