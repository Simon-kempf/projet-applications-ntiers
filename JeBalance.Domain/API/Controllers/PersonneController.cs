using API.Parameters;
using API.Resources;
using JeBalance.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using JeBalance.Domain.ValueObjects;
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
        /**
		[HttpGet]
		public async Task<IActionResult> Get([FromQuery] FindPersonnesParameter parameter)
		{
			var query = new FindPersonnesQuery(
				parameter.Limit,
				parameter.Offset,
				parameter.Nom,
				parameter.Prenom);

			var response = await _mediator.Send(query);
			Response.Headers.Add("X-Pagination-Limit", parameter.Limit.ToString());
			Response.Headers.Add("X-Pagination-Offset", parameter.Offset.ToString());
			Response.Headers.Add("X-Pagination-Count", response.Results.Count().ToString());
			Response.Headers.Add("X-Pagination-Total", response.Total.ToString());
			return Ok(response.Results);
		}
		*/

        [HttpGet]
        public async Task<IActionResult> GetOne([FromQuery] FindOnePersonneParameter parameter)
        {
            var query = new GetOnePersonneNameSurnameQuery(parameter.Nom!,parameter.Prenom!,parameter.CodePostal!,parameter.NomDeCommune!,parameter.NomDeVoie!,parameter.NumeroDeVoie!);
            var place = await _mediator.Send(query);
            return Ok(place);
        }

        [HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			var query = new GetOnePersonneQuery(id);
			var personne = await _mediator.Send(query);
			return Ok(personne);
		}


		[HttpPost]
		public async Task<IActionResult> Post([FromBody] PersonneAPICreation resource)
		{
			var command = new CreatePersonneCommand(resource.Nom, resource.Prenom, resource.Statut, resource.CodePostal, resource.NomDeCommune, resource.NomDeVoie, resource.NumeroDeVoie);
			var id = await _mediator.Send(command);
			return Ok(id);
		}

		
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] PersonneAPIUpdate resource)
		{
			var command = new UpdatePersonneCommand(id, resource.Nom, resource.Prenom, resource.Statut, resource.estVIP, resource.estCalomniateur, resource.Role, resource.CodePostal, resource.NomDeCommune, resource.NomDeVoie, resource.NumeroDeVoie);
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
