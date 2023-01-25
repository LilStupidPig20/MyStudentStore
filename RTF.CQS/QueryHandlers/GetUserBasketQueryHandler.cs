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
        var basket = await _basketService.GetStudentBasket(Guid.Parse(currentUserId), ct);
        return ConvertToFrame(basket);
    }

    private BasketFrame ConvertToFrame(Basket dataBasket)
    {
        var products = dataBasket.BasketProducts.Select(basketProduct => new BasketProductFrame
        {
            BasketProductId = basketProduct.Id,
            StoreProductId = basketProduct.Product.Id,
            Count = basketProduct.Count,
            Description = basketProduct.Product.Description,
            Name = basketProduct.Product.Name,
            ImageUrl = basketProduct.Product.Image,
            ProductPrice = basketProduct.Product.Price,
            Size = basketProduct.Size
        })
        .ToList();
        return new BasketFrame
        {
            TotalPrice = dataBasket.BasketProducts.Select(x => x.Product.Price * x.Count).Sum(),
            BasketProducts = products
        };
    }
}