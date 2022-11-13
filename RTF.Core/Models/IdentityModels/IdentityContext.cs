using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RTF.Core.Infrastructure;
using RTF.Core.Models.IdentityModels.Configuration;

namespace RTF.Core.Models.IdentityModels;

public class IdentityContext : IdentityDbContext<User>
{
    public DbSet<Student> Employees { get; set; }
    public DbSet<Admin> Admins { get; set; }

    private readonly IDbProvider _dbProvider;

    public IdentityContext(IDbProvider dbProvider)
    {
        _dbProvider = dbProvider;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(_dbProvider.GetIdentityConnectionString());
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new StudentConfiguration());
        modelBuilder.ApplyConfiguration(new AdminConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
    }
}