using Microsoft.Extensions.DependencyInjection;
using RTF.Core.Models.IdentityModels;
using RTF.Core.Repositories;

namespace RTF.Core.Infrastructure;

public class RepositoryProvider : IRepositoryProvider
{
    private readonly IServiceProvider _serviceProvider;

    public RepositoryProvider(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public T GetRepository<T>(ConnectionContext context) where T : IRepository, new()
    {
        throw new NotImplementedException();
    }
}