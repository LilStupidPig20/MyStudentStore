using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RTF.CQS.ApplicationServices;
using RTF.CQS.Converters;
using RTF.CQS.QueryHandlers;

namespace RTF.CQS.Extensions;

public static class ServiceCollectionExtension
{
    public static void RegisterRequestHandlers(this IServiceCollection services)
    {
        services.AddScoped<ICurrentUserProvider, CurrentUserProvider>();

        services.AddMediatR(typeof(ServiceCollectionExtension).Assembly);
    }
}