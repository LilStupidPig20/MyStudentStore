using RTF.Core.Models;
using RTF.Core.Models.Enums;

namespace RFT.Services.ServiceInterfaces;

public interface IOrdersService
{
    Task CreateOrder(IReadOnlyList<Guid> basketProductsIds, Guid userId, CancellationToken ct);

    Task CreateOrder(Guid storeProductId, Guid userId, int count, Size? size, CancellationToken ct);

    Task<IReadOnlyList<Order>> GetStudentOrders(Guid userId, CancellationToken ct);

    Task CancelOrder(Guid orderId, string? cancellationComment, CancellationToken ct);
}