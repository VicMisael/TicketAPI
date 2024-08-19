using Application.UseCases.Event.Query;
using Domain.Common.Utils;
using MediatR;

namespace Application.UseCases.Event.List;

public record QueryEventIn(
    int Page,
    int PerPage,
    string Query,
    string OrderBy,
    QueryOrderDir Dir):IRequest<QueryEventOut>
{
    public QueryIn ToQueryIn()
    {
        return new QueryIn(Page, PerPage, Query, OrderBy, Dir);
    }
}
