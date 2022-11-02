using Microsoft.EntityFrameworkCore;
using RTF.Core.Models;

namespace RTF.Core.Repositories;

public interface IRepository<TEntity> where TEntity : IDataModel
{
    Task<IList<TEntity>> GetAllAsync();
}