using MediatR;
using PhonePlan.Application.Commands.PhonePlans.Put;
using PhonePlan.Domain.Context;
using System.Threading;
using System.Threading.Tasks;

namespace PhonePlan.Application.Commands.PhonePlans.Delete
{
	public sealed class DeletePhonePlanCommandHandler : IRequestHandler<DeletePhonePlanCommand, Unit>
	{
		private readonly IApplicationDbContext _applicationDbContext;

		public DeletePhonePlanCommandHandler(IApplicationDbContext applicationDbContext)
		{
			_applicationDbContext = applicationDbContext;
		}

		public async Task<Unit> Handle(DeletePhonePlanCommand command, CancellationToken cancellationToken)
		{
			var phonePlan = await _applicationDbContext.PhonePlans.FindAsync(command.PlanCode);

			if (phonePlan is null)
				throw new NotFoundException("Phone plan not found");

			_applicationDbContext.PhonePlans.Remove(phonePlan);
			await _applicationDbContext.SaveChangesAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
