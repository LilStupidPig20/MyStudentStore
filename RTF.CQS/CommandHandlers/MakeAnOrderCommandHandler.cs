using RFT.Services.ServiceInterfaces;
using RTF.CQS.Abstractions;
using RTF.CQS.ApplicationServices;
using RTF.CQS.Commands;

namespace RTF.CQS.CommandHandlers;

public class MakeAnOrderCommandHandler : CommandHandler<MakeAnOrderCommand>
{
    private readonly ICurrentUserProvider _currentUserProvider;
    private readonly IOrdersService _ordersService;

    public MakeAnOrderCommandHandler(ICurrentUserProvider currentUserProvider, IOrdersService ordersService)
    {
        _currentUserProvider = currentUserProvider;
        _ordersService = ordersService;
    }

    public override async Task Handle(MakeAnOrderCommand request, CancellationToken ct)
    {
        var currentUserId = (await _currentUserProvider.GetCurrentUserAsync()).Id;
        await _ordersService.CreateOrder(request.BasketProductsIds, Guid.Parse(currentUserId), ct);
    }
}