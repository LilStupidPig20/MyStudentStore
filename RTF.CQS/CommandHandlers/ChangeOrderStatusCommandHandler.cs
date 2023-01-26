using RTF.AdminServices.Interfaces;
using RTF.CQS.Abstractions;
using RTF.CQS.Commands;

namespace RTF.CQS.CommandHandlers;

public class ChangeOrderStatusCommandHandler : CommandHandler<ChangeOrderStatusCommand>
{
    private readonly IAdminOrdersService _adminOrdersService;

    public ChangeOrderStatusCommandHandler(IAdminOrdersService adminOrdersService)
    {
        _adminOrdersService = adminOrdersService;
    }

    public override async Task Handle(ChangeOrderStatusCommand request, CancellationToken ct)
    {
        await _adminOrdersService.ChangeOrderStatus(request.OrderId, request.OrderStatus, ct);
    }
}