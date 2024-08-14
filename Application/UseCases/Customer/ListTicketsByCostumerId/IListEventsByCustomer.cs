using MediatR;

namespace Application.UseCases.Customer.ListTicketsByCostumerId;

public interface IListEventsByCustomer:IRequestHandler<ListTicketsByCustomerIn,ListTicketsByEventNameOut>
{
    
}
