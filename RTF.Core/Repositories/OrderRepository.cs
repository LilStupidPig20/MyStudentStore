using Microsoft.EntityFrameworkCore;
using RTF.Core.Models;

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
}