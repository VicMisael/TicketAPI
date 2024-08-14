using Domain.Common.Utils;

namespace Application.UseCases.Event.List;

public record EventOut(
    string Name,
    string Type,
    DateTime Date);

public record ListEventOut(
    int CurrentPage,
    int PerPage,
    int Total,
    IReadOnlyList<EventOut> Items)
{
    public static ListEventOut FromQueryOut(QueryOut<Domain.Entities.Event.Event> queryOut)
    {
        return new ListEventOut(queryOut.CurrentPage, queryOut.PerPage, queryOut.Total,
            queryOut.Items.Select(x => new EventOut(x.Name, x.Type, x.Date)).ToList());
    }
};
