using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PhonePlan.Crud.Controllers
{
	[ApiController]
	[Route("api/plans")]
	public class Plans : ControllerBase
	{
		private readonly IMediator _mediator;

		public Plans(IMediator mediator)
		{
			_mediator = mediator;
		}

		
	}
}
