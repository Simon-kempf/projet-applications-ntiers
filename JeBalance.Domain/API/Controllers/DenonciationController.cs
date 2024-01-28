using Microsoft.AspNetCore.Mvc;
using JeBalance.Domain.Model.Utilisateurs;
using JeBalance.Domain.Model;
using API.Business;
using API.Controllers.Dto;
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
			return Ok(denonciation);
		}


		[HttpPost]
		public async Task<IActionResult> Post([FromBody] DenonciationAPI resource)
		{
			var command = new CreateDenonciationCommand(resource.Horodatage, resource.Informateur, resource.Suspect, resource.Delit, resource.PaysEvasion, resource.Reponse);
			var id = await _mediator.Send(command);
			return Ok(id);
		}


		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] DenonciationAPI resource)
		{
			var command = new UpdateDenonciationCommand(id, resource.Horodatage, resource.Informateur, resource.Suspect, resource.Delit, resource.PaysEvasion, resource.Reponse);
			await _mediator.Send(command);
			return Ok(id);
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
