using Microsoft.EntityFrameworkCore;
using RTF.Core.Models;
using RTF.Core.Models.Enums;

namespace RTF.Core.Repositories;

public class OrderRepository : Repository<Order>
{
    public OrderRepository(ConnectionContext context) : base(context)
    {
    }

    public override DbSet<Order> Table { get; set; }

    public async Task<IReadOnlyList<Order>> GetUserOrders(Guid id, CancellationToken ct)
    {
        return await Table
            .Include(x => x.OrderProducts)
            .ThenInclude(x => x.Product)
            .ThenInclude(x => (x as ClothesProduct)!.ClothesInfos)
            .ToListAsync(ct);
    }

    public async Task<Order?> GetFullOrder(Guid id, CancellationToken ct)
    {
        return await Table
            .Include(x => x.Student)
            .Include(x => x.OrderProducts)
            .ThenInclude(x => x.Product)
            .ThenInclude(x => (x as ClothesProduct)!.ClothesInfos)
            .FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    public async Task<IReadOnlyList<Order>> GetAdminOrdersByStatus(IReadOnlyList<OrderStatus> statusList, CancellationToken ct)
    {
        return await Table
            .Include(x => x.Student)
            .Include(x => x.OrderProducts)
            .ThenInclude(x => x.Product)
            .Where(x => statusList.Contains(x.Status))
            .ToListAsync(ct);
    }
}