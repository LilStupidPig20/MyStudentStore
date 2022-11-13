using Microsoft.EntityFrameworkCore;
using RTF.Core.Models;

namespace RTF.Core.Repositories;

public interface IRepository<TEntity> : IRepository
    where TEntity : DataModel
{
    Task<IList<TEntity>> GetAllAsync();
    Task<TEntity> GetAsync(long id);
    Task DeleteAsync(long id);
    Task<TEntity> AddAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
}

public interface IRepository
{
}

