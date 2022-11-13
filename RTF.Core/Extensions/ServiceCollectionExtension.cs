using Microsoft.Extensions.DependencyInjection;
using RTF.Core.Infrastructure;
using RTF.Core.Repositories;

namespace RTF.Core.Extensions;

public static class ServiceCollectionExtension
{
    public static void ConfigureCoreDependencies(this IServiceCollection services)
    {
        services.AddSingleton<IDbProvider, NpgsqlProvider>();
        services.AddSingleton<IEmailConfigProvider, EmailConfigProvider>();
        services.AddScoped<IDbConnectionProvider, DbConnectionProvider>();

        //services.ConfigureRepositories();
        services.AddScoped<IRepositoryProvider, RepositoryProvider>();
    }

    private static void ConfigureRepositories(this IServiceCollection services)
    {
        services.AddScoped<StudentBalanceRepository>();
    }
}