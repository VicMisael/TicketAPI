using MediatR;

namespace Application.UseCases.Event.Create;

public interface ICreateEvent:IRequestHandler<CreateEventIn,CreateEventOut>
{
    
}
