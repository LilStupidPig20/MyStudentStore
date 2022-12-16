using RTF.Core.Models;

namespace RTF.Core.Repositories;

public class EventRepository : Repository<Event>
{
    public EventRepository(ConnectionContext context) : base(context)
    {
    }
}