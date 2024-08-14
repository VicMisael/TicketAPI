using System;
using Domain.Entities.Ticket;

namespace Infra.Persistence.Models;

public record TicketModel(
    Guid Id,
    string Code,
    Guid EventModelId,
    Guid CustomerModelId,
    DateTime CreationDate
)
{
    public EventModel? EventModel;
    public CustomerModel? CustomerModel;
    
    public Ticket FromTicketModel()
    {
        return Ticket.Create(Id, Code, CustomerModelId, EventModelId,CreationDate);
    }

    public static TicketModel ToTicketModel(Ticket ticket)
    {
        return new TicketModel(ticket.Id, ticket.Code, ticket.EventId, ticket.CustomerId,ticket.CreateDate);
    }
}
