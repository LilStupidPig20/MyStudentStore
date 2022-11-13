using Microsoft.EntityFrameworkCore;
using RTF.Core.Models;

namespace RTF.Core.Repositories;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : DataModel
{
    protected readonly ConnectionContext _context;
    protected readonly DbSet<TEntity> _table;
    protected Repository(ConnectionContext context)
    {
        _context = context;
        _context.Database.EnsureCreated();
        _table = _context.Set<TEntity>();
    }

    public async Task<IList<TEntity>> GetAllAsync()
    {
        await CheckTableExist();
        var entities = await _table.Select(x => x).ToListAsync();
        return entities;
    }

    public async Task<TEntity> GetAsync(long id)
    {
        await CheckTableExist();
        var entity = await _table.FirstOrDefaultAsync();
        if (entity == null)
        {
            throw new Exception($"Запись в таблице {typeof(TEntity)} с указанным идентификатором {id} не существует");
        }
        
        return entity;
    }

    public async Task DeleteAsync(long id)
    {
        await CheckTableExist();
        var entity = await _table.FirstOrDefaultAsync();
        if (entity == null)
        {
            throw new Exception($"Запись в таблице {typeof(TEntity)} с указанным идентификатором {id} не существует");
        }

        _table.Remove(entity);
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        //await CheckTableExist();
        if (entity.Id != 0)
        {
            var existRecord = await _table.FirstOrDefaultAsync();
            if (existRecord != null)
            {
                throw new Exception(
                    $"Запись с идентификатором {existRecord.Id} уже существует в таблице {typeof(TEntity)}");
            }
        }

        if (!await _table.AnyAsync())
        {
            entity.Id = 1;
        }
        else
        {
            entity.Id = await GetLastId() + 1;
        }
        
        var addedRecord = (await _table.AddAsync(entity)).Entity;
        return addedRecord;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        await CheckTableExist();
        var existRecord = await _table.FirstOrDefaultAsync();
        if (existRecord == null)
        {
            throw new Exception(
                $"Запись с идентификатором {entity.Id} не существует в таблице {typeof(TEntity)}");
        }

        var updated = _table.Update(entity).Entity;
        return updated;
    }

    protected async Task CheckTableExist()
    {
        if (!await _table.AnyAsync())
            throw new Exception($"Таблица {typeof(TEntity)} пуста, или не существует");
    }

    private async Task<long> GetLastId()
    {
        var lastRecord = await _table.OrderBy(x => x.Id).LastAsync();
        return lastRecord.Id;
    }
}