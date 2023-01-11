using Microsoft.EntityFrameworkCore;
using RTF.Core.Models;

namespace RTF.Core.Repositories;

public class UserInfoRepository : Repository<UserInfo>
{
    public UserInfoRepository(ConnectionContext context) : base(context)
    {
    }

    public async Task<UserInfo?> GetUserIncludeFullBasket(Guid id, CancellationToken ct)
    {
        return await Table
            .Where(x => x.Id == id)
            .Include(x => x.Basket)
            .ThenInclude(x => x.BasketProducts)
            .ThenInclude(x => x.Product)
            .ThenInclude(x => (x as ClothesProduct)!.ClothesInfos)
            .FirstOrDefaultAsync(ct);
    }

    public override DbSet<UserInfo> Table { get; set; }
}