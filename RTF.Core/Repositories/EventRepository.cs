using Microsoft.EntityFrameworkCore;
using RTF.Core.Models;

namespace RTF.Core.Repositories;

public class EventRepository : Repository<Event>
{
    public EventRepository(ConnectionContext context) : base(context)
    {
    }

    public async Task<Event?> GetEventIncludedOrganizers(Guid id, CancellationToken ct)
    {
        return await Table
            .Include(x => x.Organizers)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken: ct);
    }

    public async Task<Event?> GetEventIncludedVisitors(Guid id, CancellationToken ct)
    {
        return await Table.Include(x => x.Users)
            .FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    public override DbSet<Event> Table { get; set; }
}