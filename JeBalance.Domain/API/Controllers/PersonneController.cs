using API.Parameters;
using API.Resources;
using JeBalance.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using JeBalance.Domain.Commands.PersonneCommands;

namespace API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class PersonneController : ControllerBase
	{
		private readonly IMediator _mediator;

		public PersonneController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> Get([FromQuery] FindPersonnesParameter parameter)
		{
			var query = new FindPersonnesQuery(
				parameter.Limit,
				parameter.Offset,
				parameter.Nom,
				parameter.Prenom,
				parameter.id,
				parameter.Statut);

			var response = await _mediator.Send(query);
			Response.Headers.Add("X-Pagination-Limit", parameter.Limit.ToString());
			Response.Headers.Add("X-Pagination-Offset", parameter.Offset.ToString());
			Response.Headers.Add("X-Pagination-Count", response.Results.Count().ToString());
			Response.Headers.Add("X-Pagination-Total", response.Total.ToString());
			return Ok(response.Results);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			var query = new GetOnePersonneQuery(id);
			var personne = await _mediator.Send(query);
			return Ok(personne);
		}


		[HttpPost]
		public async Task<IActionResult> Post([FromBody] PersonneAPI resource)
		{
			var command = new CreatePersonneCommand(resource.Nom, resource.Prenom, resource.Statut, resource.Adresse);
			var id = await _mediator.Send(command);
			return Ok(id);
		}

		
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] PersonneAPI resource)
		{
			var command = new UpdatePersonneCommand(id, resource.Nom, resource.Prenom, resource.Statut, resource.Adresse);
			await _mediator.Send(command);
			return Ok(id);
		}

		
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var command = new DeletePersonneCommand(id);
			await _mediator.Send(command);
			return Ok(id);
		}
	}
}
