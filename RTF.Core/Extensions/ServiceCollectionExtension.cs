using System.Data.Entity;
using Microsoft.Extensions.DependencyInjection;
using RTF.Core.Infrastructure;
using RTF.Core.Repositories;

namespace RTF.Core.Extensions;

public static class ServiceCollectionExtension
{
    public static void ConfigureCoreServices(this IServiceCollection services)
    {
        services.AddSingleton<IDbProvider, NpgsqlProvider>();
        services.AddScoped<StudentsRepository>();
    }

    public static void ConfigureCoreServicesDependencies(this IServiceCollection services)
    {
        services.AddSingleton<IDbProvider, NpgsqlProvider>();
        services.AddScoped<StorageContext>();
        services.AddScoped<UserRepository>();
    }
}