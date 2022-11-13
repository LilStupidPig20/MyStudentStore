namespace RTF.Infrastructure.Helpers;

public class ServiceLocator
{
    private static Func<IServiceProvider> _getProvider;
    public static IServiceProvider Instance => _getProvider();

    public static void SetProvider(Func<IServiceProvider> serviceProvider)
    {
        _getProvider = serviceProvider;
    }
}