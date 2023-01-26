using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RTF.Core.Infrastructure;
using RTF.Core.Models;
using RTF.Core.Repositories;

namespace RTF.Core.Extensions;

public static class ServiceCollectionExtension
{
    public static void ConfigureCoreDependencies(this IServiceCollection services)
    {
        services.AddSingleton<IDbProvider, NpgsqlProvider>();
        services.AddSingleton<IEmailConfigProvider, EmailConfigProvider>();
    }
    
    public static IServiceCollection RegisterUnitOfWork(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
    
    public static IServiceCollection RegisterRepositories(this IServiceCollection services)
    {
        foreach (var concreteRepoType in typeof(IRepository<>)
                     .Assembly.GetTypes()
                     .Where(t => t.GetGenericInterface(typeof(IRepository<>)) != null && !t.IsAbstract && !t.IsInterface))
        {
            var dataModelType = concreteRepoType.BaseType?.GenericTypeArguments[0];
            var genericRepositoryType = typeof(IRepository<>).MakeGenericType(dataModelType!);
            services.AddScoped(genericRepositoryType, concreteRepoType);
        }

        return services;
    }
    
    public static Type? GetGenericInterface(this Type? type, Type openGenericInterface)
    {
        var metadataToken = openGenericInterface.MetadataToken;
        var module = openGenericInterface.Module;
        if (type == null || (type.MetadataToken ^ metadataToken) == 0 && (object)type.Module == (object)module)
        {
            return type;    
        }
        
        foreach (var genericInterface in type.GetInterfaces())
        {
            if ((genericInterface.MetadataToken ^ metadataToken) == 0 &&
                (object)genericInterface.Module == (object)module)
            {
                return genericInterface;
            }
        }

        return null;
    }
}