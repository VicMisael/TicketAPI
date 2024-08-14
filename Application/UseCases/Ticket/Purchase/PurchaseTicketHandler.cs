using Application.Common.Exceptions;
using Domain.Entities.Customer;
using Domain.Entities.Event;
using Domain.Entities.Ticket;

namespace Application.UseCases.Ticket.Purchase;

public class PurchaseTicketHandle(ITicketRepository ticketRepository,IEventRepository eventRepository,ICustomerRepository customerRepository):IPurchaseTicket
{
    public async Task<PurchaseOut> Handle(PurcharseIn request, CancellationToken cancellationToken)
    {
        if (!await eventRepository.ExistsById(request.EventId, cancellationToken))
        {
            throw new NotFoundException("Event not found");
            
        }
        
        if (!await customerRepository.ExistsById(request.CustomerId, cancellationToken))
        {
            throw new NotFoundException("Customer not found");
        }

        await ticketRepository.Persist(Domain.Entities.Ticket.Ticket.Create(request.CustomerId,request.EventId),cancellationToken);

        return new PurchaseOut();
    }
}
