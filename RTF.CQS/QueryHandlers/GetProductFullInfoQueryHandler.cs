using RFT.Services.ServiceInterfaces;
using RTF.Core.Models;
using RTF.Core.Models.Enums;
using RTF.CQS.Abstractions;
using RTF.CQS.ModelsFromUI.ResponseModels;
using RTF.CQS.Queries;

namespace RTF.CQS.QueryHandlers;

public class GetProductFullInfoQueryHandler : QueryHandler<GetProductFullInfoQuery, ExtendedProductInfoFrame>
{
    private readonly IStoreService _storeService;

    public GetProductFullInfoQueryHandler(IStoreService storeService)
    {
        _storeService = storeService;
    }

    public override async Task<ExtendedProductInfoFrame> Handle(GetProductFullInfoQuery request, CancellationToken ct)
    {
        var product = await _storeService.GetProduct(request.ProductId, ct);
        return Convert(product);
    }

    private ExtendedProductInfoFrame Convert(StoreProduct dataProduct)
    {
        var result = new ExtendedProductInfoFrame
        {
            Name = dataProduct.Name,
            Description = dataProduct.Description,
            Image = dataProduct.Image,
            Price = dataProduct.Price,
            ProductId = dataProduct.Id
        };
        if (dataProduct is ClothesProduct clothesProduct)
        {
            var sizesToAvailable = new Dictionary<Size, bool>();
            foreach (var clothesInfo in clothesProduct.ClothesInfos)
            {
                var available = clothesInfo.Count > 0;
                sizesToAvailable.Add(clothesInfo.Size, available);
            }

            result.SizesToAvailable = sizesToAvailable;
        }

        return result;
    }
}