using RTF.AdminServices.Interfaces;
using RTF.Core.Models;
using RTF.Core.Models.Enums;
using RTF.Core.Repositories;

namespace RTF.AdminServices.Services;

public class AdminOrdersService : IAdminOrdersService
{
    private readonly IUnitOfWork _unitOfWork;

    private static Dictionary<int, string> _statusDictionary = new()
    {
        { 0, "В обработке" },
        { 1, "Готов к получению" },
        { 2, "Получен" },
        { 3, "Отменен" }
    };

    public AdminOrdersService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IReadOnlyList<Order>> GetClosedOrders(CancellationToken ct)
    {
        var ordersRepo = (OrderRepository)_unitOfWork.GetRepository<Order>();
        var closedStatusList = new List<OrderStatus>
        {
            OrderStatus.Cancelled,
            OrderStatus.Received
        };
        var closedOrders = await ordersRepo.GetAdminOrdersByStatus(closedStatusList, ct);
        return closedOrders;
    }

    public async Task<IReadOnlyList<Order>> GetActiveOrders(CancellationToken ct)
    {
        var ordersRepo = (OrderRepository)_unitOfWork.GetRepository<Order>();
        var closedStatusList = new List<OrderStatus>
        {
            OrderStatus.Accepted,
            OrderStatus.ReadyToReceive
        };
        var closedOrders = await ordersRepo.GetAdminOrdersByStatus(closedStatusList, ct);
        return closedOrders;
    }

    public async Task<Order> GetOrderInfo(Guid orderId, CancellationToken ct)
    {
        var ordersRepo = (OrderRepository)_unitOfWork.GetRepository<Order>();
        var order = await ordersRepo.GetFullOrder(orderId, ct);
        if (order == null)
        {
            throw new ArgumentNullException($"Не удалось получить информацию по заказу с идентификатором {orderId}");
        }

        return order;
    }

    public Dictionary<int, string> GetOrderTypes()
    {
        return _statusDictionary;
    }

    public async Task ChangeOrderStatus(Guid orderId, OrderStatus status, CancellationToken ct)
    {
        var ordersRepo = _unitOfWork.GetRepository<Order>();
        var order = await ordersRepo.GetAsync(orderId);
        if (order.Status == OrderStatus.Cancelled || order.Status == OrderStatus.Received)
        {
            throw new ArgumentException("Невозможно изменить статус заказа, т.к. заказ уже получен/отменен");
        }

        order.Status = status;
        await ordersRepo.UpdateAsync(order);
        await _unitOfWork.SaveChangesAsync(ct);
    }
}