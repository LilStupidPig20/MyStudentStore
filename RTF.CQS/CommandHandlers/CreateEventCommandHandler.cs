using RTF.AdminServices.DtoModels;
using RTF.AdminServices.Interfaces;
using RTF.CQS.Abstractions;
using RTF.CQS.Commands;

namespace RTF.CQS.CommandHandlers;

public class CreateEventCommandHandler : CommandHandler<CreateEventCommand, bool>
{
    private readonly IAdminInfoService _adminInfoService;
    private readonly IEventAdminService _eventAdminService;

    public CreateEventCommandHandler(IAdminInfoService adminInfoService, IEventAdminService eventAdminService)
    {
        _adminInfoService = adminInfoService;
        _eventAdminService = eventAdminService;
    }

    public override async Task<bool> HandleWithResult(CreateEventCommand request, CancellationToken ct)
    {
        var eventDto = new EventAdminDto
        {
            Name = request.Name,
            Description = request.Description,
            Coins = request.Coins,
            Organizers = request.Organizers,
            StartDateTime = request.StartDateTime,
            EndDateTime = request.EndDateTime,
            EventType = request.EventType
        };

        await _eventAdminService.CreateEventAsync(eventDto, ct);

        return true;
    }
}