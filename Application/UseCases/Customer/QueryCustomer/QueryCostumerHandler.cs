using Domain.Entities.Customer;

namespace Application.UseCases.Customer.QueryCustomer;

public class QueryCostumerHandler(ICustomerRepository customerRepository):IQueryCustomer
{
    public async Task<QueryCustomerOut> Handle(QueryCustomerIn request, CancellationToken cancellationToken)
    {
        var queryOut = await customerRepository.Query(request.ToQueryIn(), cancellationToken);

        return QueryCustomerOut.FromQueryOut(queryOut);
    }
}
