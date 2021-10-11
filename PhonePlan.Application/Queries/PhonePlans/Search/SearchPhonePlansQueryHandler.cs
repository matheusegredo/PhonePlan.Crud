using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PhonePlan.Domain.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PhonePlan.Application.Queries.PhonePlans.Search
{
	public class SearchPhonePlansQueryHandler : IRequestHandler<SearchPhonePlansQuery, List<SearchPhonePlansQueryResponse>>
	{
		private readonly IMapper _mapper;
		private readonly IApplicationDbContext _applicationDbContext;

		public SearchPhonePlansQueryHandler(IMapper mapper, IApplicationDbContext applicationDbContext)
		{
			_mapper = mapper;
			_applicationDbContext = applicationDbContext;
		}

		public Task<List<SearchPhonePlansQueryResponse>> Handle(SearchPhonePlansQuery request, CancellationToken cancellationToken)
		{
			var phonePlanQuery = _applicationDbContext.DirectRemoteDialingPhonePlan
				.Include(p => p.PhonePlans)
				.Include(p => p.DirectRemoteDialing)
				.Where(phonePlan => Equals(phonePlan.DirectRemoteDialing.Code, request.DDD))
				.AsQueryable();

			if (request.PlanCode is not null)
				phonePlanQuery = phonePlanQuery.Where(phonePlan => Equals(phonePlan.PhonePlanCode, request.PlanCode));

			if (!string.IsNullOrWhiteSpace(request.Operator))
				phonePlanQuery = phonePlanQuery.Where(phonePlan => Equals(phonePlan.PhonePlans.Operator, request.Operator));

			if (request.PlanType is not null)
				phonePlanQuery = phonePlanQuery.Where(phonePlan => Equals(phonePlan.PhonePlans.PlanType, request.PlanType));			

			return phonePlanQuery
				.ProjectTo<SearchPhonePlansQueryResponse>(_mapper.ConfigurationProvider)
				.ToListAsync(cancellationToken);
		}
	}
}