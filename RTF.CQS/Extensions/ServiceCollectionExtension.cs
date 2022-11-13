using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RTF.CQS.QueryHandlers;

namespace RTF.CQS.Extensions;

public static class ServiceCollectionExtension
{
    public static void RegisterRequestHandlers(this IServiceCollection services)
    {
        services.AddMediatR(typeof(ServiceCollectionExtension).Assembly);
        //.AddMediatR(typeof(LoginQueryHandler).Assembly);
    }
}