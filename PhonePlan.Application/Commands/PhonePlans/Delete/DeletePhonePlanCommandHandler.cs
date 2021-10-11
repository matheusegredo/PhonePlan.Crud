using MediatR;
using Microsoft.EntityFrameworkCore;
using PhonePlan.CrossCutting.Exceptions;
using PhonePlan.Domain.Context;
using PhonePlan.Domain.Entities;
using System.Linq;
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
			var phonePlan = await _applicationDbContext.PhonePlans
				.Where(phonePlan => phonePlan.PlanCode == command.PlanCode)
				.Select(p => new PhonePlansEntity { PlanCode = p.PlanCode })
				.FirstOrDefaultAsync(cancellationToken);

			if (phonePlan is null)
				throw new NotFoundException("Phone plan not found");

			if (string.IsNullOrEmpty(command.DDD))
				_applicationDbContext.PhonePlans.Remove(phonePlan);
			else
			{
				var directRemoteDialing = await _applicationDbContext.DirectRemoteDialing
					.Where(ddd => ddd.Code == command.DDD)
					.Select(p => new DirectRemoteDialingEntity { DirectRemoteDialingCode = p.DirectRemoteDialingCode })
					.FirstOrDefaultAsync(cancellationToken);

				if (directRemoteDialing is null)
					throw new NotFoundException("Direct Remote Dialing not found");

				var directRemoteDialingPhonePlanEntity = await _applicationDbContext.DirectRemoteDialingPhonePlan
					.Where(dddPhonePlan => dddPhonePlan.DirectRemoteDialingCode == directRemoteDialing.DirectRemoteDialingCode
										&& dddPhonePlan.PhonePlanCode == command.PlanCode)
					.Select(p => new DirectRemoteDialingPhonePlanEntity { DirectRemoteDialingPhonePlanCode = p.DirectRemoteDialingPhonePlanCode })
					.FirstOrDefaultAsync(cancellationToken);

				_applicationDbContext.DirectRemoteDialingPhonePlan.Remove(directRemoteDialingPhonePlanEntity);
			}

			await _applicationDbContext.SaveChangesAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
