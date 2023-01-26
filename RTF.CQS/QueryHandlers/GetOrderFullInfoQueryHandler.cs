using RTF.AdminServices.Interfaces;
using RTF.Core.Models;
using RTF.CQS.Abstractions;
using RTF.CQS.ModelsFromUI.AdminResponseModels;
using RTF.CQS.Queries;

namespace RTF.CQS.QueryHandlers;

public class GetOrderFullInfoQueryHandler : QueryHandler<GetOrderFullInfoQuery, AdminOrderExtendedInfo>
{
    private readonly IAdminOrdersService _adminOrdersService;

    public GetOrderFullInfoQueryHandler(IAdminOrdersService adminOrdersService)
    {
        _adminOrdersService = adminOrdersService;
    }

    public override async Task<AdminOrderExtendedInfo> Handle(GetOrderFullInfoQuery request, CancellationToken ct)
    {
        var order = await _adminOrdersService.GetOrderInfo(request.OrderId, ct);
        var convertedResult = Convert(order);
        return convertedResult;
    }

    private AdminOrderExtendedInfo Convert(Order dataOrder)
    {
        var products = new List<AdminOrderProductFrame>();
        foreach (var dataProduct in dataOrder.OrderProducts)
        {
            if (dataProduct.Size != null)
            {
                products.Add(new AdminClothesOrderProductFrame
                {
                    ProductId = dataProduct.Id,
                    Count = dataProduct.Count,
                    Description = dataProduct.Product.Description,
                    Name = dataProduct.Product.Name,
                    Price = dataProduct.Price,
                    Size = dataProduct.Size.Value,
                    ImageUrl = dataProduct.Product.Image
                });
            }
            else
            {
                products.Add(new AdminOrderProductFrame
                {
                    ProductId = dataProduct.Id,
                    Count = dataProduct.Count,
                    Description = dataProduct.Product.Description,
                    Name = dataProduct.Product.Name,
                    Price = dataProduct.Price,
                    ImageUrl = dataProduct.Product.Image
                });
            }
        }

        return new AdminOrderExtendedInfo
        {
            OrderId = dataOrder.Id,
            Status = dataOrder.Status,
            StudentFullName = $"{dataOrder.Student.LastName} {dataOrder.Student.FirstName}",
            PurchaseDate = dataOrder.PurchaseTime,
            OrderProducts = products
        };
    }
}