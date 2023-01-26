using RFT.Services.DtoModels;
using RFT.Services.ServiceInterfaces;
using RTF.CQS.Abstractions;
using RTF.CQS.ApplicationServices;
using RTF.CQS.Commands;

namespace RTF.CQS.CommandHandlers;

public class RemoveProductFromBasketCommandHandler : CommandHandler<RemoveProductFromBasketCommand>
{
    private readonly ICurrentUserProvider _currentUserProvider;
    private readonly IBasketService _basketService;

    public RemoveProductFromBasketCommandHandler(ICurrentUserProvider currentUserProvider, IBasketService basketService)
    {
        _currentUserProvider = currentUserProvider;
        _basketService = basketService;
    }

    public override async Task Handle(RemoveProductFromBasketCommand request, CancellationToken ct)
    {
        var currentUserId = (await _currentUserProvider.GetCurrentUserAsync()).Id;
        var dto = new OrderProductDto
        {
            ProductId = request.ProductId,
            Size = request.Size
        };
        await _basketService.RemoveProductFromBasket(dto, Guid.Parse(currentUserId), ct);
    }
}