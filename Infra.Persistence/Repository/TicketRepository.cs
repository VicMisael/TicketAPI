using Domain.Entities.Customer;
using Domain.Entities.Ticket;
using Infra.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace Infra.Persistence.Repository;

public class TicketRepository(ApplicationDbContext context) : ITicketRepository
{
    private DbSet<TicketModel> Tickets => context.Set<TicketModel>();

    public async Task Persist(Ticket ticket, CancellationToken cancellationToken)
    {
        await Tickets.AddAsync(TicketModel.ToTicketModel(ticket),cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public Task<List<Customer>> FindCostumersByEventId(Guid eventId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
