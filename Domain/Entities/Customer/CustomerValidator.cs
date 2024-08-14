using System;
using FluentValidation;

namespace Domain.Entities.Customer;

public class CustomerValidator:AbstractValidator<Customer>
{
    public CustomerValidator()
    {
        RuleFor(customer => customer.Name).NotNull();
        RuleFor(customer => customer.EmailAddress).NotNull().EmailAddress();
        RuleFor(customer => customer.BirthDate)
            .NotNull()
            .Must(date => DateTime.Today >= date.AddYears(18))
            .WithMessage("Customer must be at least 18 years old.");

    }
}
