using Domain.Common.Utils;
using Domain.Entities.Event;
using Domain.Entities.Ticket;

namespace Application.UseCases.Customer.ListTicketsByCostumerId;

public record TicketDto(
    string EventName,
    string Code
    );


public record ListTicketsByEventNameOut(
    int CurrentPage,
    int PerPage,
    int Total,
    IReadOnlyList<TicketDto> Items)
{

    public static ListTicketsByEventNameOut FromEventTicketTupleQueryIn(QueryOut<Tuple<Domain.Entities.Event.Event, Domain.Entities.Ticket.Ticket>> @in)
    {
        var list=@in.Items.Select(x => new TicketDto(x.Item1.Name, x.Item2.Code));
        return new ListTicketsByEventNameOut(@in.CurrentPage, @in.PerPage, @in.Total,
            list.ToList());
    }
};
