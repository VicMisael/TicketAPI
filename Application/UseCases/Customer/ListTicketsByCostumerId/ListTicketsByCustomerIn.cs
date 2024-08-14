using Domain.Common.Utils;
using MediatR;

namespace Application.UseCases.Customer.ListTicketsByCostumerId;

public record ListTicketsByCustomerIn(
    int Page,
    int PerPage,
    string Query,
    string OrderBy,
    QueryOrderDir Dir,
    Guid CustomerId) : IRequest<ListTicketsByEventNameOut>
{
    public QueryIn GetQueryIn()
    {
        return new QueryIn(Page, PerPage, Query, OrderBy, Dir);
    }
};
