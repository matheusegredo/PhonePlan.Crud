using AutoMapper;
using MediatR;
using PhonePlan.Application.Commands.PhonePlans.Put;
using PhonePlan.Application.Profiles;
using PhonePlan.Application.Queries.PhonePlans.Search;
using PhonePlan.CrossCutting.Exceptions;
using PhonePlan.Domain.Entities;
using System.Threading.Tasks;
using Xunit;

namespace PhonePlan.Crud.Application.Test.Commands
{
	[Trait("Command", "PhonePlan")]
	public sealed class SearchPhonePlansQueryHandlerTest
	{
		private readonly SearchPhonePlansQueryHandler _handler;

		public SearchPhonePlansQueryHandlerTest()
		{
			var mapper = new MapperConfiguration(cfg => cfg.AddProfile(new PhonePlansProfiles())).CreateMapper();
			var context = ApplicationDbContextFactory.Create();

			_handler = new SearchPhonePlansQueryHandler(mapper, context);
		}		
	}
}
