using AutoMapper;
using MediatR;
using PhonePlan.CrossCutting.Exceptions;
using PhonePlan.Domain.Context;
using System.Threading;
using System.Threading.Tasks;

namespace PhonePlan.Application.Commands.PhonePlans.Put
{
	public class PutPhonePlanCommandHandler : IRequestHandler<PutPhonePlanCommand, Unit>
	{
		private readonly IMapper _mapper;
		private readonly IApplicationDbContext _applicationDbContext;

		public PutPhonePlanCommandHandler(IMapper mapper, IApplicationDbContext applicationDbContext)
		{
			_mapper = mapper;
			_applicationDbContext = applicationDbContext;
		}

		public async Task<Unit> Handle(PutPhonePlanCommand command, CancellationToken cancellationToken)
		{
			var phonePlan = await _applicationDbContext.PhonePlans.FindAsync(command.PlanCode);

			if (phonePlan is null)
				throw new NotFoundException("Phone plan not found");

			_mapper.Map(command, phonePlan);

			await _applicationDbContext.SaveChangesAsync(cancellationToken);

			return Unit.Value;
		}
	}
}