using Application.UseCases.Event.List;
using Domain.Common.Utils;
using MediatR;

namespace Application.UseCases.Customer.QueryCustomer;

public record QueryCustomerIn(
    int Page,
    int PerPage,
    string Query,
    string OrderBy,
    QueryOrderDir Dir) : IRequest<QueryCustomerOut>
{
    public QueryIn ToQueryIn()
    {
        return new QueryIn(Page, PerPage, Query, OrderBy, Dir);
    }
};
