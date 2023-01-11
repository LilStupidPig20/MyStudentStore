using RTF.Core.Models;

namespace RFT.Services.ServiceInterfaces;

public interface IOrdersService
{
    Task CreateOrder(IReadOnlyList<Guid> basketProductsIds, Guid userId, CancellationToken ct);

    Task<IReadOnlyList<Order>> GetStudentOrders(Guid userId, CancellationToken ct);

    Task CancelOrder(Guid orderId, string? cancellationComment, CancellationToken ct);
}