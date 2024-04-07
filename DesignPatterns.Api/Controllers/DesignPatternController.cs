using DesignPatterns.App.FactoryPattern.Queries.CheckConnection;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns.Controllers;

[ApiController]
public sealed class DesignPatternController(ISender mediator) : ControllerBase
{
	[HttpGet("[action]")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public async Task<IActionResult> CheckConnectionToDb()
	{
		var result = await mediator.Send(new CheckConnectionQuery());
		return Ok(result);
	}
}