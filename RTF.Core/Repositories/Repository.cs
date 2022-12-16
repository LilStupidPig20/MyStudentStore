using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RTF.Core.Models;

namespace RTF.Core.Repositories;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : DataModel
{
    protected readonly ConnectionContext Context;
    protected readonly DbSet<TEntity> Table;

    protected Repository(ConnectionContext context)
    {
        Context = context;
        Context.Database.EnsureCreated();
        Table = Context.Set<TEntity>();
    }

    public async Task<IReadOnlyList<TEntity>> GetAllAsync()
    {
        var entities = await Table.Select(x => x).ToListAsync();
        return entities;
    }

    public async Task<TEntity> GetAsync(long id)
    {
        var entity = await Table.FirstOrDefaultAsync(x => x.Id == id);
        if (entity == null)
        {
            throw new Exception($"Запись в таблице {typeof(TEntity)} с указанным идентификатором {id} не существует");
        }
        
        return entity;
    }

    public async Task DeleteAsync(long id)
    {
        var entity = await Table.FirstOrDefaultAsync(x => x.Id == id);
        if (entity == null)
        {
            throw new Exception($"Запись в таблице {typeof(TEntity)} с указанным идентификатором {id} не существует");
        }

        Table.Remove(entity);
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        if (entity.Id != 0)
        {
            var existRecord = await Table.FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (existRecord != null)
            {
                throw new Exception(
                    $"Запись с идентификатором {existRecord.Id} уже существует в таблице {typeof(TEntity)}");
            }
        }

        if (!await Table.AnyAsync())
        {
            entity.Id = 1;
        }
        else
        {
            entity.Id = await GetLastId() + 1;
        }
        
        var addedRecord = (await Table.AddAsync(entity)).Entity;
        return addedRecord;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        var existRecord = await Table.FirstOrDefaultAsync(x => x.Id == entity.Id);
        if (existRecord == null)
        {
            throw new Exception(
                $"Запись с идентификатором {entity.Id} не существует в таблице {typeof(TEntity)}");
        }

        var updated = Table.Update(entity).Entity;
        return updated;
    }

    public async Task<TEntity?> FindOneBy(Expression<Func<TEntity, bool>> predicate)
    {
        var result = await Table.FindAsync(predicate);
        return result;
    }

    public Task<IReadOnlyList<TEntity>> FindBy(Expression<Func<TEntity, bool>> predicate)
    {
        var result = Table.Where(predicate);
        return Task.FromResult<IReadOnlyList<TEntity>>(result.ToList());
    }

    protected async Task CheckTableExist()
    {
        if (!await Table.AnyAsync())
            throw new Exception($"Таблица {typeof(TEntity)} пуста, или не существует");
    }

    protected async Task<long> GetLastId()
    {
        var lastRecord = await Table.OrderBy(x => x.Id).LastAsync();
        return lastRecord.Id;
    }
}