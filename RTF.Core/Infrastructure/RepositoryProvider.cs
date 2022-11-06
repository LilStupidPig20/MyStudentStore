using RTF.Core.Repositories;

namespace RTF.Core.Infrastructure;

public class RepositoryProvider : IRepositoryProvider
{
    //TODO разобраться с адекватной поставкой экземпляров репозиториев
    // private readonly Dictionary<Type, Func<StorageContext, IRepository>> _reposDictionary = new()
    // {
    //     { typeof(User), context => new UserRepository(context) }
    // };
    //
    // public IRepository GetRepository<TEntity>(StorageContext context) where TEntity : class, IDataModel
    // {
    //     if (!_reposDictionary.ContainsKey(typeof(TEntity)))
    //     {
    //         throw new Exception($"Для указанного типа {typeof(TEntity)} не определен репозиторий");
    //     }
    //
    //     return _reposDictionary[typeof(TEntity)].Invoke(context);
    // }

    public StudentRepository StudentRepository(ConnectionContext context) => new(context);
}