using MediatR;

namespace Application.UseCases.Customer.QueryCustomer;

public interface IQueryCustomer:IRequestHandler<QueryCustomerIn,QueryCustomerOut>
{
    
}
