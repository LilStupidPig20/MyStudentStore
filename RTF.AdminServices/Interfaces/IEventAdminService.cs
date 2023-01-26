using RTF.AdminServices.DtoModels;
using RTF.Core.Models;

namespace RTF.AdminServices.Interfaces;

public interface IEventAdminService
{
    Task CreateEventAsync(EventAdminDto eventAdminDto, CancellationToken cancellationToken);

    Task<Event> GetEventWithVisitorsAsync(Guid eventId, CancellationToken ct);

    Task CheckInUser(Guid userQr, Guid eventId, CancellationToken ct);
}