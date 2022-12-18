using Microsoft.EntityFrameworkCore;
using RTF.Core.Infrastructure;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace RTF.Core.Repositories;

public class ConnectionContext : DbContext
{
    private readonly IDbProvider _dbProvider;

    public ConnectionContext(DbContextOptions<ConnectionContext> options, IDbProvider dbProvider)
        : base(options)
    {
        _dbProvider = dbProvider;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(_dbProvider.GetDbConnectionString());
        }
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}