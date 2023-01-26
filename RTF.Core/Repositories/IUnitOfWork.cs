using RTF.Core.Models;

namespace RTF.Core.Repositories;

public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// Асинхронно сохраняет все изменения, совершенные в рамках транзакции.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>Количество записей состояния, сохраненных в базу данных.</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    
    /// <summary>
    /// Сохраняет все изменения, совершенные в рамках транзакции.
    /// </summary>
    /// <returns>Количество записей состояния, сохраненных в базу данных.</returns>
    int SaveChanges();
    
    /// <summary>
    /// Получить нужный репозиторий по типу модели данных.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <returns></returns>
    IRepository<TEntity> GetRepository<TEntity>() where TEntity : DataModel;
}