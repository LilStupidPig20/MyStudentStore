using Microsoft.EntityFrameworkCore;
using RTF.Core.Infrastructure;
using RTF.Core.Models;

namespace RTF.Core.Repositories;

public class StorageContext : DbContext
{
    private readonly IDbProvider _dbProvider;
    public DbSet<User> Users { get; set; }

    public StorageContext(IDbProvider dbProvider)
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