using Microsoft.Extensions.DependencyInjection;
using RTF.AdminServices.Interfaces;
using RTF.AdminServices.Services;

namespace RTF.AdminServices.Extensions;

public static class ServiceCollectionExtension
{
    public static void ConfigureAdminServicesDependencies(this IServiceCollection services)
    {
        services.AddScoped<IAdminInfoService, AdminInfoService>();
        services.AddScoped<IEventAdminService, EventAdminService>();
    }
}