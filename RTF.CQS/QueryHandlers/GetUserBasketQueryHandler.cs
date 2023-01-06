using RFT.Services.ServiceInterfaces;
using RTF.Core.Models;
using RTF.CQS.Abstractions;
using RTF.CQS.ApplicationServices;
using RTF.CQS.ModelsFromUI.ResponseModels;
using RTF.CQS.Queries;

namespace RTF.CQS.QueryHandlers;

public class GetUserBasketQueryHandler : QueryHandler<GetUserBasketQuery, BasketFrame>
{
    private readonly ICurrentUserProvider _currentUserProvider;
    private readonly IBasketService _basketService;

    public GetUserBasketQueryHandler(ICurrentUserProvider currentUserProvider, IBasketService basketService)
    {
        _currentUserProvider = currentUserProvider;
        _basketService = basketService;
    }

    public override async Task<BasketFrame> Handle(GetUserBasketQuery request, CancellationToken ct)
    {
        var currentUserId = (await _currentUserProvider.GetCurrentUserAsync()).Id;
        var basket = await _basketService.GetStudentBasket(Guid.Parse(currentUserId));
        return ConvertToFrame(basket);
    }

    private BasketFrame ConvertToFrame(Basket dataBasket)
    {
        var products = dataBasket.OrderProducts?.Select(product => new OrderProductFrame
        {
            ProductId = product.Id,
            Count = product.Count,
            Description = product.Product.Description,
            Name = product.Product.Name,
            ImageUrl = product.Product.Image,
            ProductPrice = product.Product.Price
        })
        .ToList();
        return new BasketFrame
        {
            TotalPrice = dataBasket.TotalPrice,
            Products = products ?? new List<OrderProductFrame>()
        };
    }
}