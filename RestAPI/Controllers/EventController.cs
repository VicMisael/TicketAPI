using Application.UseCases.Customer.Create;
using Application.UseCases.Event.Create;
using Application.UseCases.Event.List;
using Application.UseCases.Event.Query;
using Domain.Common.Utils;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Common;

namespace RestAPI.Controllers;


[ApiController]
[Route("api/events")]
public class EventController(IMediator mediator) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> ListEvents(

        CancellationToken cancellationToken,
        [FromQuery] string? query = null,
        [FromQuery] string? orderBy = null,
        [FromQuery] bool? showPastEvents =null,
        [FromQuery] QueryOrderDir? dir = null,
        [FromQuery] int? perPage=null,
        [FromQuery] int? page=null )
    {
        var listEventIn = new QueryEventIn(   Math.Max(page ?? 1, 1),
            PerPage:  Math.Max(perPage ?? 15, 1),
            Query: query ?? "",
            OrderBy: orderBy ?? "name",
            Dir: dir ?? QueryOrderDir.Desc,
            ShowPastEvents: showPastEvents??false);

        var result = await mediator.Send(listEventIn, cancellationToken);

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateEventOut), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> CreateEvent([FromBody] CreateEventIn input, CancellationToken cancellationToken)
    {

        var result = await mediator.Send(input, cancellationToken);

        return CreatedAtAction(
            nameof(CreateEvent),
            result
        );

    }
}
    

