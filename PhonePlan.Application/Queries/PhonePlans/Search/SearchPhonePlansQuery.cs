using MediatR;
using PhonePlan.Domain.Entities;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace PhonePlan.Application.Queries.PhonePlans.Search
{
	public class SearchPhonePlansQuery : IRequest<List<SearchPhonePlansQueryResponse>>
	{
		public int? PlanCode { get; set; }

		public PlanType? PlanType { get; set; }

		public string Operator { get; set; }

		public string DDD { get; set; }
	}
}