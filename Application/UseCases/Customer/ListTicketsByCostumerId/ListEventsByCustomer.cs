using Application.Common.Exceptions;
using Domain.Entities.Customer;

namespace Application.UseCases.Customer.ListTicketsByCostumerId;

public class ListEventsByCustomer(ICustomerRepository customerRepository):IListEventsByCustomer
{
    
    
    public async Task<ListTicketsByEventNameOut> Handle(ListTicketsByCustomerIn request, CancellationToken cancellationToken)
    {
        if (!await customerRepository.ExistsById(request.CustomerId,cancellationToken))
        {
            throw new NotFoundException("Customer not found");
        }
        
        var result = await customerRepository.FindCustomerEvents(request.CustomerId,request.GetQueryIn() ,cancellationToken);
        return ListTicketsByEventNameOut.FromEventTicketTupleQueryIn(result);
    }
}
    
