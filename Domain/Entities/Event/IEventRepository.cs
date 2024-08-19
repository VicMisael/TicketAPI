using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Common.Utils;

namespace Domain.Entities.Event;

public interface IEventRepository
{
    Task Persist(Event @event, CancellationToken cancellationToken);

    Task<QueryOut<Event>> Query(QueryIn queryIn, bool pastEvents,CancellationToken cancellationToken);
    
    Task<bool> ExistsById(Guid id, CancellationToken cancellationToken);
}
