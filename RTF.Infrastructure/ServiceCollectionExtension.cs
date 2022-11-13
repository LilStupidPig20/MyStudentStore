using Microsoft.Extensions.DependencyInjection;
using RTF.Infrastructure.Helpers;

namespace RTF.Infrastructure;

public static class ServiceCollectionExtension
{
    public static void AddInfrastructureServicedDependencies(this IServiceCollection services)
    {
       services.AddScoped<ITokenGenerator, TokenGenerator>();
    }
}