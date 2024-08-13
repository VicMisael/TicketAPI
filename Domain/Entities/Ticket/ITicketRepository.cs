namespace Domain.Entities.Ticket;

public interface ITicketRepository
{
    Task Persist(Ticket ticket, CancellationToken cancellationToken);

    Task<List<Customer.Customer>> FindCostumersByEventId(Guid eventId, CancellationToken cancellationToken);
    
    
}
