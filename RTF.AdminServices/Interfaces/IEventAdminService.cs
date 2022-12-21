using RTF.AdminServices.DtoModels;

namespace RTF.AdminServices.Interfaces;

public interface IEventAdminService
{
    Task CreateEventAsync(EventAdminDto eventAdminDto, CancellationToken cancellationToken);
}