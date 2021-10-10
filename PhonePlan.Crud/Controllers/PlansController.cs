using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhonePlan.Application.Commands.PhonePlans.Delete;
using PhonePlan.Application.Commands.PhonePlans.Post;
using PhonePlan.Application.Commands.PhonePlans.Put;
using PhonePlan.Application.Queries.PhonePlans.Search;
using System.Threading.Tasks;

namespace PhonePlan.Crud.Controllers
{
	[ApiController]
	[Route("api/plans")]
	public class PlansController : ControllerBase
	{
		private readonly IMediator _mediator;

		public PlansController(IMediator mediator)
		{
			_mediator = mediator;
		}


		[HttpGet]
		[ProducesResponseType(typeof(SearchPhonePlansQueryResponse), 200)]
		public async Task<IActionResult> Get([FromQuery] SearchPhonePlansQuery query)
		{
			return Ok(await _mediator.Send(query));
		}

		[HttpDelete("{id}")]		
		[ProducesResponseType(typeof(Unit), 200)]
		public async Task<IActionResult> Get([FromRoute] int id)
		{
			return Ok(await _mediator.Send(new DeletePhonePlanCommand(id)));
		}

		[HttpPost]
		[ProducesResponseType(201)]
		public async Task<IActionResult> Post([FromBody] PostPhonePlanCommand command)
		{
			return Created(string.Empty, await _mediator.Send(command));
		}

		[HttpPut]
		[ProducesResponseType(typeof(Unit), 200)]
		public async Task<IActionResult> Put([FromBody] PutPhonePlanCommand command)
		{
			return Ok(await _mediator.Send(command));
		}
	}
}
