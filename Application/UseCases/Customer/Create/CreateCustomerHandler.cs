using Domain.Entities.Customer;

namespace Application.UseCases.Customer.Create;

public class CreateCustomerHandler(ICustomerRepository customerRepository) : ICreateCustomer
{
    public async Task<CreateCustomerOut> Handle(CreateCustomerIn request, CancellationToken cancellationToken)
    {
        await customerRepository.Persist(request.ToCustomer(),cancellationToken);

        return new CreateCustomerOut();
    }
}
