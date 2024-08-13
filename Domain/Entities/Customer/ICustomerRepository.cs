using Domain.Common.Utils;

namespace Domain.Entities.Customer;

public interface ICustomerRepository
{
    Task Persist(Customer costumer, CancellationToken cancellationToken);

    Task<QueryOut<Customer>> Query(QueryIn queryIn, CancellationToken cancellationToken);

}
