using Domain.Common.Utils;
using Domain.Entities.Customer;
using Domain.Entities.Event;
using Domain.Entities.Ticket;
using Infra.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace Infra.Persistence.Repository;

public class CustomerRepository(ApplicationDbContext context):ICustomerRepository
{
    private DbSet<CustomerModel> Customers => context.Set<CustomerModel>();
    private DbSet<TicketModel> Tickets = context.Set<TicketModel>();
    public async Task Persist(Customer customer, CancellationToken cancellationToken)
    {
        await Customers.AddAsync(new CustomerModel(customer.Id, customer.Name, customer.EmailAddress,customer.BirthDate), cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<QueryOut<Customer>> Query(QueryIn queryIn, CancellationToken cancellationToken)
    {
        var toSkip = (queryIn.Page - 1) * queryIn.PerPage;
        var query = Customers.AsNoTracking();

        query = (queryIn.OrderBy.ToLower(), QueryOrderDir: queryIn.Dir) switch
        {
            ("name", QueryOrderDir.Asc) => query.OrderBy(x => x.Name).ThenBy(x => x.Id),
            ("name", QueryOrderDir.Desc) => query.OrderByDescending(x => x.Name).ThenByDescending(x => x.Id),
            ("emailaddress", QueryOrderDir.Asc) => query.OrderBy(x => x.Email).ThenBy(x => x.Id),
            ("emailaddress", QueryOrderDir.Desc) => query.OrderByDescending(x => x.Email).ThenByDescending(x => x.Id),
            ("birthdate", QueryOrderDir.Asc) => query.OrderBy(x => x.BirthDate).ThenBy(x => x.Id),
            ("birthdate", QueryOrderDir.Desc) => query.OrderByDescending(x => x.BirthDate).ThenByDescending(x => x.Id),
            _ => query.OrderBy(x => x.Id)
        };

        if (!string.IsNullOrWhiteSpace(queryIn.Query))
        {
            query = query.Where(x =>
                x.Name.ToLower().Contains(queryIn.Query.ToLower()) ||
                x.Email.ToLower().Contains(queryIn.Query.ToLower())
            );
        }
        

        var total = await query.CountAsync(cancellationToken: cancellationToken);

        var items = await query
            .Skip(toSkip)
            .Take(queryIn.PerPage)
            .ToListAsync(cancellationToken: cancellationToken);

        return new QueryOut<Customer>(
            queryIn.Page,
            queryIn.PerPage,
            total,
            items.Select(x => Customer.Create(x.Id,x.Name,x.Email,x.BirthDate)).ToList() 
        );
    }

    public async Task<bool> ExistsById(Guid id, CancellationToken cancellationToken)
    {
      return  Customers.AsQueryable().Any(x => x.Id == id);
    }

    public async Task<QueryOut<Tuple<Event, Ticket>>> FindCustomerEvents(Guid customerId, QueryIn queryIn, CancellationToken cancellationToken)
    {
         var toSkip = (queryIn.Page - 1) * queryIn.PerPage;

         var query = Tickets
             .Where(ticket => ticket.CustomerModelId == customerId).Include(x=>x.EventModel)
             .AsQueryable();
         
    
    

    query= (queryIn.OrderBy.ToLower(), queryIn.Dir) switch
    {
        ("eventname", QueryOrderDir.Asc) => query.OrderBy(ticket => ticket.EventModel!.Name).ThenBy(ticket => ticket.Id),
        ("eventname", QueryOrderDir.Desc) => query.OrderByDescending(ticket => ticket.EventModel!.Name).ThenByDescending(ticket => ticket.Id),
        ("eventdate", QueryOrderDir.Asc) => query.OrderBy(ticket => ticket.EventModel!.Date).ThenBy(ticket => ticket.Id),
        ("eventdate", QueryOrderDir.Desc) => query.OrderByDescending(ticket => ticket.EventModel!.Date).ThenByDescending(ticket => ticket.Id),
        _ => query.OrderBy(ticket => ticket.Id)
    };
    
    if (!string.IsNullOrWhiteSpace(queryIn.Query))
    {
        query = query.Where(ticket =>
            ticket.EventModel != null && (ticket.EventModel.Name.ToLower().Contains(queryIn.Query.ToLower()) ||
                                          ticket.Code.ToLower().Contains(queryIn.Query.ToLower()))
        );
    }
    
    var total = await query.CountAsync(cancellationToken);

    var items = await query
        .Skip(toSkip)
        .Take(queryIn.PerPage)
        .ToListAsync(cancellationToken);

    var result = items.Select(ticket =>
            Tuple.Create( Event.Create(ticket.EventModel!.Id, ticket.EventModel!.Name, 
                ticket.EventModel!.Type, ticket.EventModel!.Date),
                Ticket.Create(ticket.Id,ticket.Code,ticket.CustomerModelId,ticket.EventModelId,ticket.CreationDate)))
        .ToList();

  
    return new QueryOut<Tuple<Event, Ticket>>(
        queryIn.Page,
        queryIn.PerPage,
        total,
        result
    );
    }
}
