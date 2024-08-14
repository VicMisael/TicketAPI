using MediatR;

namespace Application.UseCases.Customer.Create;

public interface ICreateCustomer:IRequestHandler<CreateCustomerIn,CreateCustomerOut>
{
    
}
