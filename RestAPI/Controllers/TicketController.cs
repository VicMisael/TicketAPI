using Application.UseCases.Ticket.Purchase;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RestAPI.Controllers;

[ApiController]
[Route("api/tickets")]
public class TicketController(IMediator mediator):ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> MakePurchase([FromBody] PurchaseIn purchaseIn, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(purchaseIn, cancellationToken);
        return Ok(result);

    }
}
