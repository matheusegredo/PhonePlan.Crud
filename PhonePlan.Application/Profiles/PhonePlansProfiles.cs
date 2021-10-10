using AutoMapper;
using PhonePlan.Application.Commands.PhonePlans.Post;
using PhonePlan.Application.Queries.PhonePlans.Search;
using PhonePlan.Domain.Entities;
using System;

namespace PhonePlan.Application.Profiles
{
	public sealed class PhonePlansProfiles : Profile
	{
		public PhonePlansProfiles()
		{
			CreateMap<PostPhonePlanCommand, PhonePlansEntity>();

			CreateMap<PhonePlansEntity, SearchPhonePlansQueryResponse>()
				.ForMember(dest => dest.PlanType, o => o.MapFrom(src => Enum.GetName(src.PlanType)));
		}
	}
}
