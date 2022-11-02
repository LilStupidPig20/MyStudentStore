using Microsoft.EntityFrameworkCore;
using RTF.Core.Infrastructure;
using RTF.Core.Models;

namespace RTF.Core.Repositories;

public abstract class BaseRepository<TEntity> : DbContext, IRepository<TEntity> where TEntity : class, IDataModel
{
    private readonly IDbProvider _dbProvider;
    protected DbSet<TEntity> DbEntity => Set<TEntity>();

    protected BaseRepository(IDbProvider dbProvider)
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

    public async Task<IList<TEntity>> GetAllAsync()
    {
        if (!await DbEntity.AnyAsync())
            throw new Exception($"Таблица {typeof(TEntity)} пуста, или не существует");
        return DbEntity.Select(x => x).ToList();
    }
}