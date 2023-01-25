using RFT.Services.ServiceInterfaces;
using RTF.CQS.Abstractions;
using RTF.CQS.ApplicationServices;
using RTF.CQS.Commands;

namespace RTF.CQS.CommandHandlers;

public class MakeOrderRightNowCommandHandler : CommandHandler<MakeOrderRightNowCommand>
{
    private readonly ICurrentUserProvider _currentUserProvider;
    private readonly IOrdersService _ordersService;

    public MakeOrderRightNowCommandHandler(ICurrentUserProvider currentUserProvider, IOrdersService ordersService)
    {
        _currentUserProvider = currentUserProvider;
        _ordersService = ordersService;
    }

    public override async Task Handle(MakeOrderRightNowCommand request, CancellationToken ct)
    {
        var currentUserId = (await _currentUserProvider.GetCurrentUserAsync()).Id;
        await _ordersService
            .CreateOrder(request.StoreProductId, Guid.Parse(currentUserId), request.Count, request.Size, ct);
    }
}