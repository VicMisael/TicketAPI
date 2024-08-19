using Application.UseCases.Event.Query;
using MediatR;

namespace Application.UseCases.Event.List;

public interface IQueryEvent:IRequestHandler<QueryEventIn,QueryEventOut>
{
    
}
