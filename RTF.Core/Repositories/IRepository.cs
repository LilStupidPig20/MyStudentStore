using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RTF.Core.Models;

namespace RTF.Core.Repositories;

public interface IRepository<TEntity> where TEntity : DataModel
{
    Task<IReadOnlyList<TEntity>> GetAllAsync();
    Task<TEntity> GetAsync(long id);
    Task DeleteAsync(long id);
    Task<TEntity> AddAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task<TEntity?> FindOneBy(Expression<Func<TEntity, bool>> predicate);
    Task<IReadOnlyList<TEntity>> FindBy(Expression<Func<TEntity, bool>> predicate);
}


