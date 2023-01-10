using RFT.Services.ServiceInterfaces;
using RTF.CQS.Abstractions;
using RTF.CQS.Commands;

namespace RTF.CQS.CommandHandlers;

public class CancelOrderCommandHandler : CommandHandler<CancelOrderCommand>
{
    private readonly IOrdersService _ordersService;

    public CancelOrderCommandHandler(IOrdersService ordersService)
    {
        _ordersService = ordersService;
    }

    public override async Task Handle(CancelOrderCommand request, CancellationToken ct)
    {
        await _ordersService.CancelOrder(request.OrderId, request.CancellationComment, ct);
    }
}