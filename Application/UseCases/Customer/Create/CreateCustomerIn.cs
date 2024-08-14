using MediatR;

namespace Application.UseCases.Customer.Create;

public record CreateCustomerIn(
    string Name,
    string Email,
    DateTime BirthDate) : IRequest<CreateCustomerOut>
{
    public Domain.Entities.Customer.Customer ToCustomer()
    {
        return Domain.Entities.Customer.Customer.Create(Name,Email,BirthDate);
    } 
};
