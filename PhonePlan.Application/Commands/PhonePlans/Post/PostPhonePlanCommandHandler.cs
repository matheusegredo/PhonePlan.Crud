using AutoMapper;
using MediatR;
using PhonePlan.Domain.Context;
using PhonePlan.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PhonePlan.Application.Commands.PhonePlans.Post
{
	public class PostPhonePlanCommandHandler : IRequestHandler<PostPhonePlanCommand, int>
	{
		private readonly IMapper _mapper;
		private readonly IApplicationDbContext _applicationDbContext;

		public PostPhonePlanCommandHandler(IMapper mapper, IApplicationDbContext applicationDbContext)
		{
			_mapper = mapper;
			_applicationDbContext = applicationDbContext;
		}

		public async Task<int> Handle(PostPhonePlanCommand command, CancellationToken cancellationToken)
		{
			var phonePlan = _mapper.Map<PhonePlansEntity>(command);
			_applicationDbContext.PhonePlans.Add(phonePlan);

			await _applicationDbContext.SaveChangesAsync(cancellationToken);

			return phonePlan.PlanCode;
		}
	}
}