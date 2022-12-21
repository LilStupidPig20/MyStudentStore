using Microsoft.EntityFrameworkCore;
using RTF.Core.Infrastructure;
using RTF.Core.Models;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace RTF.Core.Repositories;

public sealed class ConnectionContext : DbContext
{
    private readonly IDbProvider _dbProvider;

    private DbSet<UserInfo> UsersInfo { get; set; }
    private DbSet<Event> Events { get; set; }
    private DbSet<StoreProduct> Products { get; set; }  
    private DbSet<ClothesProduct> Clothes { get; set; }
    private DbSet<AdminInfo> AdminsInfo { get; set; }

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