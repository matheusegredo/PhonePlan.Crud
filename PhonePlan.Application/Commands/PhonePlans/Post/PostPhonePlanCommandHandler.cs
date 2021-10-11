using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PhonePlan.CrossCutting.Exceptions;
using PhonePlan.Domain.Context;
using PhonePlan.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PhonePlan.Application.Commands.PhonePlans.Post
{
	public class PostPhonePlanCommandHandler : IRequestHandler<PostPhonePlanCommand, Unit>
	{
		private readonly IMapper _mapper;
		private readonly IApplicationDbContext _applicationDbContext;

		public PostPhonePlanCommandHandler(IMapper mapper, IApplicationDbContext applicationDbContext)
		{
			_mapper = mapper;
			_applicationDbContext = applicationDbContext;
		}

		public async Task<Unit> Handle(PostPhonePlanCommand command, CancellationToken cancellationToken)
		{
			var directRemoteDialingPhonePlan = new DirectRemoteDialingPhonePlanEntity();

			if (command.PlanCode is null)
				directRemoteDialingPhonePlan.PhonePlans = _mapper.Map<PhonePlansEntity>(command.PhonePlanData);
			else
			{
				var phonePlans = await _applicationDbContext.PhonePlans
					.Where(phonePlan => phonePlan.PlanCode == command.PlanCode.Value)
					.Select(p => new PhonePlansEntity { PlanCode = p.PlanCode })
					.FirstOrDefaultAsync(cancellationToken);

				if (phonePlans is null)
					throw new NotFoundException("Phone plan not found");

				directRemoteDialingPhonePlan.PhonePlanCode = phonePlans.PlanCode;
			}

			var directRemoteDialing = await _applicationDbContext.DirectRemoteDialing
				.Where(ddd => Equals(ddd.Code, command.DDD))
				.Select(p => new DirectRemoteDialingEntity { DirectRemoteDialingCode = p.DirectRemoteDialingCode, Code = p.Code })
				.FirstOrDefaultAsync(cancellationToken);

			if (directRemoteDialing is null)
				directRemoteDialingPhonePlan.DirectRemoteDialing = _mapper.Map<DirectRemoteDialingEntity>(command);
			else
				directRemoteDialingPhonePlan.DirectRemoteDialingCode = directRemoteDialing.DirectRemoteDialingCode;

			_applicationDbContext.DirectRemoteDialingPhonePlan.Add(directRemoteDialingPhonePlan);
			await _applicationDbContext.SaveChangesAsync(cancellationToken);

			return Unit.Value;
		}
	}
}