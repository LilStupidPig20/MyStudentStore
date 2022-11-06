using Microsoft.Extensions.DependencyInjection;
using RFT.Services.ServiceInterfaces;
using RFT.Services.Services;

namespace RFT.Services.Extensions;

public static class ServiceCollectionExtension
{
    public static void ConfigureServicesDependencies(this IServiceCollection services)
    {
        services.AddScoped<IStudentService, StudentService>();
    }
}