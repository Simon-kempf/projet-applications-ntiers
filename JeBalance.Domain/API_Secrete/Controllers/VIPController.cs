using Microsoft.AspNetCore.Mvc;
using MediatR;
using API_Secrete.Parameters;
using JeBalance.Domain.Queries.VIP;
using JeBalance.Domain.Commands.VIPCommands;
using JeBalance.Domain.Queries;
using JeBalance.Domain.Commands.PersonneCommands;

namespace API_Secrete.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class VIPController : ControllerBase
	{
		private readonly IMediator _mediator;

		public VIPController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			var query = new GetOneVIPQuery(id);
			var personne = await _mediator.Send(query);
			return Ok(personne);
		}

		[HttpGet]
		public async Task<IActionResult> Find([FromQuery] FindVIPsParameter parameter)
		{
			var query = new FindVIPsQuery(parameter.Limit, parameter.Offset);
			var personne = await _mediator.Send(query);
			return Ok(personne.Results);
		}


		[HttpPut("ajouter/{id}")]
		public async Task<IActionResult> Put(int id)
		{
			var command = new CreateVIPCommand(id);
			var result = await _mediator.Send(command);
			return Ok(result);
		}


		[HttpPut("retirer/{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var command = new DeleteVIPCommand(id);
			var result = await _mediator.Send(command);
			return Ok(result);
		}
	}
}
