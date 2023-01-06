using Microsoft.Extensions.DependencyInjection;
using RFT.Services.Helpers;
using RFT.Services.ServiceInterfaces;
using RFT.Services.Services;

namespace RFT.Services.Extensions;

public static class ServiceCollectionExtension
{
    public static void ConfigureServicesDependencies(this IServiceCollection services)
    {
        services.AddScoped<IDataInitializer, DataInitializer>();
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IStudentBalanceService, StudentBalanceService>();
        services.AddScoped<IUserInfoService, UserInfoService>();
        services.AddScoped<IEventService, EventService>();
        services.AddScoped<IStoreService, StoreService>();
        services.AddScoped<IBasketService, BasketService>();
    }
}