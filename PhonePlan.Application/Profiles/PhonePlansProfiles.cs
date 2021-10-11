using AutoMapper;
using PhonePlan.Application.Commands.PhonePlans.Post;
using PhonePlan.Application.Commands.PhonePlans.Put;
using PhonePlan.Application.Queries.PhonePlans.Search;
using PhonePlan.Domain.Entities;
using System;

namespace PhonePlan.Application.Profiles
{
	public sealed class PhonePlansProfiles : Profile
	{
		public PhonePlansProfiles()
		{
			CreateMap<PostPhonePlanDataCommand, PhonePlansEntity>();

			CreateMap<PostPhonePlanCommand, DirectRemoteDialingEntity>()
				.ForMember(dest => dest.Code, o => o.MapFrom(src => src.DDD));

			CreateMap<PutPhonePlanCommand, PhonePlansEntity>();

			CreateMap<DirectRemoteDialingPhonePlanEntity, SearchPhonePlansQueryResponse>()
				.ForMember(dest => dest.DDD, o => o.MapFrom(src => src.DirectRemoteDialing.Code))
				.IncludeMembers(p => p.PhonePlans);

			CreateMap<DirectRemoteDialingEntity, SearchPhonePlansQueryResponse>();				

			CreateMap<PhonePlansEntity, SearchPhonePlansQueryResponse>()
				.ForMember(dest => dest.PlanType, o => o.MapFrom(src => Enum.GetName(src.PlanType)));
		}
	}
}
