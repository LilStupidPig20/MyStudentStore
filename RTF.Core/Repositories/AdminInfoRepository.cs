using Microsoft.EntityFrameworkCore;
using RTF.Core.Models;

namespace RTF.Core.Repositories;

public class AdminInfoRepository : Repository<AdminInfo>
{
    public AdminInfoRepository(ConnectionContext context) : base(context)
    {
    }

    public override DbSet<AdminInfo> Table { get; set; }
}