using RFT.Services.ServiceInterfaces;
using RTF.Core.Models;
using RTF.CQS.Abstractions;
using RTF.CQS.ApplicationServices;
using RTF.CQS.ModelsFromUI.ResponseModels;
using RTF.CQS.Queries;

namespace RTF.CQS.QueryHandlers;

public class GetStudentOrdersQueryHandler : QueryHandler<GetStudentOrdersQuery, IReadOnlyList<OrderFrame>>
{
    private readonly ICurrentUserProvider _currentUserProvider;
    private readonly IOrdersService _ordersService;

    public GetStudentOrdersQueryHandler(ICurrentUserProvider currentUserProvider, IOrdersService ordersService)
    {
        _currentUserProvider = currentUserProvider;
        _ordersService = ordersService;
    }

    public override async Task<IReadOnlyList<OrderFrame>> Handle(GetStudentOrdersQuery request, CancellationToken ct)
    {
        var currentUserId = (await _currentUserProvider.GetCurrentUserAsync()).Id;
        var orders = await _ordersService.GetStudentOrders(Guid.Parse(currentUserId), ct);
        return orders.Select(ConvertToFrame).ToList();
    }

    private OrderFrame ConvertToFrame(Order dataOrder)
    {
        return new OrderFrame
        {
            OrderId = dataOrder.Id,
            Status = dataOrder.Status,
            TimeOfOrder = dataOrder.PurchaseTime,
            OrderProducts = dataOrder.OrderProducts.Select(x => new OrderProductFrame
                {
                    ProductId = x.Product.Id,
                    Count = x.Count,
                    Size = x.Size,
                    Name = x.Product.Name,
                    Price = x.Price,
                    ImageUrl = x.Product.Image
                })
                .ToList()
        };
    }
}