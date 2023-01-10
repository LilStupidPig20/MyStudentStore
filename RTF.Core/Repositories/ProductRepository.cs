using Microsoft.EntityFrameworkCore;
using RTF.Core.Models;

namespace RTF.Core.Repositories;

public class ProductRepository : Repository<StoreProduct>
{
    public ProductRepository(ConnectionContext context) : base(context)
    {
    }

    public async Task<IReadOnlyList<StoreProduct>> LoadAllProductsIncludedClothes(CancellationToken ct)
    {
        return await Table
            .Include(x => (x as ClothesProduct)!.ClothesInfos)
            .ToListAsync(ct);
    }

    public override DbSet<StoreProduct> Table { get; set; }
}