using Application.UseCases.Event.List;
using Domain.Entities.Event;

namespace Application.UseCases.Event.Query;

public class QueryEventHandler(IEventRepository eventRepository):IQueryEvent
{
    public async Task<QueryEventOut> Handle(QueryEventIn request, CancellationToken cancellationToken)
    {
      var queryOut = await eventRepository.Query(request.ToQueryIn(),request.ShowPastEvents, cancellationToken);
      return QueryEventOut.FromQueryOut(queryOut);
    }
}
