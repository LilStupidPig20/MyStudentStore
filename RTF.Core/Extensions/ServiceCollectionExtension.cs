using System.Data.Entity;
using Microsoft.Extensions.DependencyInjection;
using RTF.Core.Infrastructure;
using RTF.Core.Repositories;

namespace RTF.Core.Extensions;

public static class ServiceCollectionExtension
{
    public static void ConfigureCoreDependencies(this IServiceCollection services)
    {
        services.AddSingleton<IDbProvider, NpgsqlProvider>();
        services.AddScoped<IDbConnectionProvider, DbConnectionProvider>();
        services.AddScoped<IRepositoryProvider, RepositoryProvider>();
    }
}