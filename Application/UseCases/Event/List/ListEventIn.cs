using Domain.Common.Utils;
using MediatR;

namespace Application.UseCases.Event.List;

public record ListEventIn(
    int Page,
    int PerPage,
    string Query,
    string OrderBy,
    QueryOrderDir Dir):IRequest<ListEventOut>
{
    public QueryIn toQueryIn()
    {
        return new QueryIn(Page, PerPage, Query, OrderBy, Dir);
    }
}
