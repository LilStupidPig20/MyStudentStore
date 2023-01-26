using RFT.Services.ServiceInterfaces;
using RTF.CQS.Abstractions;
using RTF.CQS.ApplicationServices;
using RTF.CQS.Commands;

namespace RTF.CQS.CommandHandlers;

public class DecrementProductInBasketCommandHandler : CommandHandler<DecrementProductInBasketCommand>
{
    private readonly ICurrentUserProvider _currentUserProvider;
    private readonly IBasketService _basketService;

    public DecrementProductInBasketCommandHandler(ICurrentUserProvider currentUserProvider, IBasketService basketService)
    {
        _currentUserProvider = currentUserProvider;
        _basketService = basketService;
    }

    public override async Task Handle(DecrementProductInBasketCommand request, CancellationToken ct)
    {
        var currentUserId = (await _currentUserProvider.GetCurrentUserAsync()).Id;
        await _basketService.DecrementProductCount(request.BasketProductId, Guid.Parse(currentUserId), ct);
    }
}