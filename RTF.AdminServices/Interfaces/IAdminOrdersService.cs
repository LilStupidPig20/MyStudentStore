using RTF.Core.Models;
using RTF.Core.Models.Enums;

namespace RTF.AdminServices.Interfaces;

public interface IAdminOrdersService
{
    Task<IReadOnlyList<Order>> GetClosedOrders(CancellationToken ct);

    Task<IReadOnlyList<Order>> GetActiveOrders(CancellationToken ct);
    
    Task<Order> GetOrderInfo(Guid orderId, CancellationToken ct);

    Dictionary<int, string> GetOrderTypes();

    Task ChangeOrderStatus(Guid orderId, OrderStatus status, CancellationToken ct);
}