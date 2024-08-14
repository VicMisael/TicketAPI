using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Common.Utils;

namespace Domain.Entities.Customer;

public interface ICustomerRepository
{
    Task Persist(Customer customer, CancellationToken cancellationToken);

    Task<QueryOut<Customer>> Query(QueryIn queryIn, CancellationToken cancellationToken);

    Task<bool> ExistsById(Guid id, CancellationToken cancellationToken);
    
    Task<QueryOut<Tuple<Event.Event,Ticket.Ticket>>> FindCustomerEvents(Guid customerId,QueryIn @in, CancellationToken cancellationToken);

}
