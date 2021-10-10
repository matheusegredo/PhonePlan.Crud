using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PhonePlan.Domain.Context;
using System.Collections.Generic;
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
			return _applicationDbContext.PhonePlans
				.ProjectTo<SearchPhonePlansQueryResponse>(_mapper.ConfigurationProvider)
				.ToListAsync(cancellationToken);
		}
	}
}