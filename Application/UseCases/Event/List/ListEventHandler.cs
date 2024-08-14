using Domain.Common.Utils;
using Domain.Entities.Event;

namespace Application.UseCases.Event.List;

public class ListEventHandler(IEventRepository eventRepository):IListEvent
{
    public async Task<ListEventOut> Handle(ListEventIn request, CancellationToken cancellationToken)
    {
      var queryOut= await eventRepository.Query(request.toQueryIn(), cancellationToken);
      return ListEventOut.FromQueryOut(queryOut);
    }
}
