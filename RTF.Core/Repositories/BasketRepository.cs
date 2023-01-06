using RTF.Core.Models;

namespace RTF.Core.Repositories;

public class BasketRepository : Repository<Basket>
{
    public BasketRepository(ConnectionContext context) : base(context)
    {
    }
}