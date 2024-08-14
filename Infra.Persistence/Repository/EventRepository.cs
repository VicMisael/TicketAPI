using Domain.Common.Utils;
using Domain.Entities.Event;
using Infra.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace Infra.Persistence.Repository;

public class EventRepository(ApplicationDbContext context):IEventRepository
{
    private DbSet<EventModel> Events => context.Set<EventModel>();
    public async Task Persist(Event eventEntity, CancellationToken cancellationToken)
    {
        await Events.AddAsync(
            new EventModel(eventEntity.Id, eventEntity.Name, eventEntity.Type, eventEntity.Date), cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<QueryOut<Event>> Query(QueryIn queryIn, CancellationToken cancellationToken)
    {
        // Calculate the number of records to skip based on the current page and items per page
        var toSkip = (queryIn.Page - 1) * queryIn.PerPage;

        // Start with a basic query that tracks no entities to improve performance
        var query = Events.AsNoTracking();

        // Apply ordering based on the OrderBy and Dir properties
        query = (queryIn.OrderBy.ToLower(), QueryOrderDir: queryIn.Dir) switch
        {
            ("name", QueryOrderDir.Asc) => query.OrderBy(x => x.Name).ThenBy(x => x.Id),
            ("name", QueryOrderDir.Desc) => query.OrderByDescending(x => x.Name).ThenByDescending(x => x.Id),
            ("type", QueryOrderDir.Asc) => query.OrderBy(x => x.Type).ThenBy(x => x.Id),
            ("type", QueryOrderDir.Desc) => query.OrderByDescending(x => x.Type).ThenByDescending(x => x.Id),
            ("date", QueryOrderDir.Asc) => query.OrderBy(x => x.Date).ThenBy(x => x.Id),
            ("date", QueryOrderDir.Desc) => query.OrderByDescending(x => x.Date).ThenByDescending(x => x.Id),
            _ => query.OrderBy(x => x.Id) // Default ordering if none is specified
        };

        // Apply the filter based on the Query parameter
        if (!string.IsNullOrWhiteSpace(queryIn.Query))
        {
            query = query.Where(x =>
                x.Name.ToLower().Contains(queryIn.Query.ToLower()) ||
                x.Type.ToLower().Contains(queryIn.Query.ToLower())
            );
        }


        var total = await query.CountAsync(cancellationToken: cancellationToken);
        
        var items = await query
            .Skip(toSkip)
            .Take(queryIn.PerPage)
            .ToListAsync(cancellationToken: cancellationToken);
        
        var result = new QueryOut<Event>(
            queryIn.Page,
            queryIn.PerPage,
            total,
            items.Select(x => Event.Create(x.Id, x.Name, x.Type, x.Date)).ToList()
        );

        return result;
    }

    public async Task<bool> ExistsById(Guid id, CancellationToken cancellationToken)
    {
        return await Task.FromResult(Events.AsQueryable().Count(x => x.Id == id) > 0);
    }
}
