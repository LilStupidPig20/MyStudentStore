using Microsoft.EntityFrameworkCore;
using RTF.Core.Models;
using RTF.Core.Repositories;

namespace RTF.Core.Infrastructure;

public class DbConnectionProvider : IDbConnectionProvider
{
    private readonly IDbProvider _dbProvider;

    public DbConnectionProvider(IDbProvider dbProvider)
    {
        _dbProvider = dbProvider;
    }

    public ConnectionContext GetDbConnection()
    {
        return new ConnectionContext(_dbProvider);
    }
}