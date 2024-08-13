using Domain.Common.Utils;

namespace Domain.Entities.Event;

public interface IEventRepository
{
    Task Persist(Event @event, CancellationToken cancellationToken);

    Task<QueryOut<Event>> Query(QueryIn queryIn, CancellationToken cancellationToken);
}
