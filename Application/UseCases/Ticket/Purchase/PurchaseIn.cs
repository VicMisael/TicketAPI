using MediatR;

namespace Application.UseCases.Ticket.Purchase;

public record PurchaseIn(Guid CustomerId,Guid EventId):IRequest<PurchaseOut>;
