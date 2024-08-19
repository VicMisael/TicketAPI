using Domain.Common.Utils;

namespace Application.UseCases.Event.Query;

public record EventOut(
    string Id,
    string Name,
    string Type,
    DateTime Date);

public record QueryEventOut(
    int CurrentPage,
    int PerPage,
    int Total,
    IReadOnlyList<EventOut> Items)
{
    public static QueryEventOut FromQueryOut(QueryOut<Domain.Entities.Event.Event> queryOut)
    {
        return new QueryEventOut(queryOut.CurrentPage, queryOut.PerPage, queryOut.Total,
            queryOut.Items.Select(x => new EventOut(x.Id.ToString(),x.Name, x.Type, x.Date)).ToList());
    }
};
