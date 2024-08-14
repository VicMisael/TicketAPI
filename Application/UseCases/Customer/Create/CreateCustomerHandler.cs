using Domain.Entities.Customer;

namespace Application.UseCases.Customer.Create;

public class CreateCustomerHandler(ICustomerRepository customerRepository) : ICreateCustomer
{
    public async Task<CreateCustomerOut> Handle(CreateCustomerIn request, CancellationToken cancellationToken)
    {
        var costumer = request.ToCustomer();
        await customerRepository.Persist(costumer,cancellationToken);

        return new CreateCustomerOut(costumer.Id);
    }
}
