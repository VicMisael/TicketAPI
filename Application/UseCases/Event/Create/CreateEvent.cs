using Domain.Entities.Event;

namespace Application.UseCases.Event.Create;

public class CreateEvent(IEventRepository eventRepository):ICreateEvent
{
    public async Task<CreateEventOut> Handle(CreateEventIn request, CancellationToken cancellationToken)
    {
        var @event=Domain.Entities.Event.Event.Create(request.Name, request.Type, request.EventDate);
        await eventRepository.Persist(@event,cancellationToken);

        return new CreateEventOut();
    }
}
