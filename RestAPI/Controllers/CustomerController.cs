using Application.UseCases.Customer.Create;
using Application.UseCases.Customer.ListTicketsByCostumerId;
using Domain.Common.Utils;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Common;

namespace RestAPI.Controllers;

[ApiController]
[Route("api/customers")]
public class CustomerController(IMediator mediator):ControllerBase
{
    
    [HttpPost]
    [ProducesResponseType(typeof(CreateCustomerOut), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerIn input, CancellationToken cancellationToken)
    {
   
            var result = await mediator.Send(input, cancellationToken);
                
            return CreatedAtAction(
                nameof(CreateCustomer),
                result
            );

    }
    
    [HttpGet("{customerId}/tickets")]
    public async Task<IActionResult> ListTicketsByCustomer( 
        [FromRoute] Guid customerId,
        CancellationToken cancellationToken,
        [FromQuery] string? query = null,
        [FromQuery] string? orderBy = null,
        [FromQuery] QueryOrderDir? dir = null,
        [FromQuery] int? perPage=null,
        [FromQuery] int? page=null )
    {
        

        var listTicketsByCustomerIn = new ListTicketsByCustomerIn(
            Page: Math.Max(page ?? 1, 1),
            PerPage: Math.Max(perPage ?? 15, 1),
            Query: query ?? "",
            OrderBy: orderBy ?? "name",
            Dir: dir ?? QueryOrderDir.Desc,
            customerId);
            
        var result = await mediator.Send(listTicketsByCustomerIn, cancellationToken);
            
        return Ok(result);
    }
    
    
}
