using DesignPatterns.App.UseCases.FactoryPattern.Queries.CheckConnection;
using DesignPatterns.Common.CheckConnection;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns.Controllers;

[ApiController]
public sealed class ConnectionsController(ISender mediator) : ControllerBase
{
	[HttpGet("[action]")]
	[ProducesResponseType(typeof(CheckConnectionResponse), StatusCodes.Status200OK)]
	public async Task<IActionResult> CheckConnectionToDb()
	{
		var result = await mediator.Send(new CheckConnectionQuery());
		return Ok(result);
	}
}