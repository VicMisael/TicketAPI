using MediatR;

namespace Application.UseCases.Ticket.Purchase;

public interface IPurchaseTicket:IRequestHandler<PurcharseIn,PurchaseOut>
{
    
}
