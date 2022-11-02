namespace RTF.Core.Stores;

public interface IRepository<TEntity>
{
    Task<TEntity> GetSingle(long? id);
    Task<IList<TEntity>> GetAll();
    Task Add(TEntity entity);
    Task Remove(TEntity entity);
    Task RemoveByIndex(long? index);
    Task Update(TEntity entity);
    Task<TEntity> GetFirst();
}