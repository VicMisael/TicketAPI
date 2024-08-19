using FluentValidation;

namespace Domain.Entities.Event;

public class EventValidator:AbstractValidator<Event>
{
    public EventValidator()
    {
        RuleFor(customer => customer.Name).NotNull();
        RuleFor(customer => customer.Type).NotNull();
        RuleFor(customer => customer.Date)
            .NotNull()
            .Must(date => DateTime.UtcNow<date.ToUniversalTime())
            .WithMessage("The event should be happening in the future");

    }
}
