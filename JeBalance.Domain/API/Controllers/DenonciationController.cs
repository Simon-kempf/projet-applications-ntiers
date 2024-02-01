using Microsoft.AspNetCore.Mvc;
using JeBalance.Domain.Model;
using System;
using API.Parameters;
using API.Resources;
using JeBalance.Domain.Commands.PersonneCommands;
using JeBalance.Domain.Queries;
using MediatR;
using JeBalance.Domain.Commands.DenonciationCommands;
using JeBalance.Domain.Queries.Denonciations;

namespace API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class DenonciationController : ControllerBase
	{
		private readonly IMediator _mediator;

		public DenonciationController(IMediator mediator)
		{
			_mediator = mediator;
		}


		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			var query = new GetOneDenonciationQuery(id);
			var denonciation = await _mediator.Send(query);
			if(denonciation == null)
			{
				return BadRequest("Aucune dénonciation ne correspond à cet identifiant");
			}
			return Ok(denonciation);
		}

		[HttpGet("non-traitees")]
		public async Task<IActionResult> GetNonTraitees([FromQuery] FindNonTraiteesParameter parameter)
		{
			var query = new FindDenonciationsNonTraiteesQuery(parameter.Limit, parameter.Offset);
			var reponse = await _mediator.Send(query);
			return Ok(reponse.Results);
		}


		[HttpPost]
		public async Task<IActionResult> Post([FromBody] DenonciationCreationAPI resource)
		{
			var command = new CreateDenonciationCommand(resource.NomInformateur, resource.PrenomInformateur, resource.CodePostalInformateur, resource.NomDeCommuneInformateur, resource.NumeroDeVoieInformateur, resource.NomDeVoieInformateur,
				resource.NomSuspect, resource.PrenomSuspect, resource.CodePostalSuspect, resource.NomDeCommuneSuspect, resource.NumeroDeVoieSuspect, resource.NomDeVoieSuspect, resource.Delit, resource.PaysEvasion);
			var id = await _mediator.Send(command);
			return Ok(id);
		}


		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] DenonciationUpdateAPI resource)
		{
			var command = new UpdateDenonciationCommand(id, resource.TypeReponse, resource.Retribution);
			int retour = await _mediator.Send(command);
			if (retour == -1)
			{
				return BadRequest("Aucune dénonciation ne correspond à cet identifiant");
			}
			return Ok(retour);
		}


		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var command = new DeleteDenonciationCommand(id);
			await _mediator.Send(command);
			return Ok(id);
		}
	}
}
