using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace RTF.CQS.Extensions;

public static class ServiceCollectionExtension
{
    public static void RegisterRequestHandlers(this IServiceCollection services)
    {
        services.AddMediatR(typeof(ServiceCollectionExtension).Assembly);
    }
}