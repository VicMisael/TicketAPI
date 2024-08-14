using MediatR;

namespace Application.UseCases.Ticket.Purchase;

public record PurcharseIn(Guid CustomerId,Guid EventId):IRequest<PurchaseOut>;
