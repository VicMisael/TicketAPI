using MediatR;

namespace Application.UseCases.Event.Create;

public record CreateEventIn(
    string Name,
    string Type,
    DateTime EventDate):IRequest<CreateEventOut>;
