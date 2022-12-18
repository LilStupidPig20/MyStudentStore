using RTF.Core.Models;

namespace RTF.Core.Repositories;

public class ProductRepository : Repository<StoreProduct>
{
    public ProductRepository(ConnectionContext context) : base(context)
    {
    }
}