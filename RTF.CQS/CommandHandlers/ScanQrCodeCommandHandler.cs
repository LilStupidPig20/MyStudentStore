using RTF.AdminServices.Interfaces;
using RTF.CQS.Abstractions;
using RTF.CQS.Commands;

namespace RTF.CQS.CommandHandlers;

public class ScanQrCodeCommandHandler : CommandHandler<ScanQrCodeCommand>
{
    private readonly IEventAdminService _eventAdminService;

    public ScanQrCodeCommandHandler(IEventAdminService eventAdminService)
    {
        _eventAdminService = eventAdminService;
    }

    public override async Task Handle(ScanQrCodeCommand request, CancellationToken ct)
    {
        await _eventAdminService.CheckInUser(request.UserQrId, request.EventId, ct);
    }
}