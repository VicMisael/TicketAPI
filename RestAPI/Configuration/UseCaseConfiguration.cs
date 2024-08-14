
using System.Reflection;
using Application;
using Domain.Entities.Customer;
using Domain.Entities.Event;
using Domain.Entities.Ticket;
using Infra.Persistence.Repository;

namespace RestAPI.Configuration;

public static class UseCasesConfiguration
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        var assemblies = Assembly.Load("Application");
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblies(assemblies);
        });
        services.AddTransient<ITicketRepository, TicketRepository>();
        services.AddTransient<IEventRepository,EventRepository>();
        services.AddTransient<ICustomerRepository,CustomerRepository>();
        
        
        
        return services;
    }
    
}

