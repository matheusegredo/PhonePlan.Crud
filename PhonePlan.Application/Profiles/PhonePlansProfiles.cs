using AutoMapper;
using PhonePlan.Application.Commands.PhonePlans.Post;
using PhonePlan.Domain.Entities;

namespace PhonePlan.Application.Profiles
{
	public sealed class PhonePlansProfiles : Profile
	{
		public PhonePlansProfiles()
		{
			CreateMap<PostPhonePlanCommand, PhonePlansEntity>();
		}
	}
}
