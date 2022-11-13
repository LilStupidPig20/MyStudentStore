using Microsoft.EntityFrameworkCore;
using RTF.Core.Models;
using RTF.Core.Repositories;

namespace RTF.Core.Infrastructure;

public interface IRepositoryProvider
{ 
    T GetRepository<T>(ConnectionContext context) where T : IRepository, new();
}