using MediatR;
using System.Collections.Generic;

namespace PhonePlan.Application.Queries.PhonePlans.Search
{
	public class SearchPhonePlansQuery : IRequest<List<SearchPhonePlansQueryResponse>>
	{		
	}
}