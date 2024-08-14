using MediatR;

namespace Application.UseCases.Event.List;

public interface IListEvent:IRequestHandler<ListEventIn,ListEventOut>
{
    
}
