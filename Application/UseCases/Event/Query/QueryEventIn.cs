using Domain.Common.Utils;
using MediatR;

namespace Application.UseCases.Event.Query;

public record QueryEventIn(
    int Page,
    int PerPage,
    string Query,
    string OrderBy,
    bool ShowPastEvents,
    QueryOrderDir Dir):IRequest<QueryEventOut>
{
    public QueryIn ToQueryIn()
    {
        return new QueryIn(Page, PerPage, Query, OrderBy, Dir);
    }
}
