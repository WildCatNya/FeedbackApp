using Feedback.Server.ServiceInstallers.Abstraction;
using System.Reflection;

namespace Feedback.Server.Extensions;

public static class ServiceExtension
{
    public static IServiceCollection InstallServices(this IServiceCollection services, IConfiguration configuration, params Assembly[] assemblies)
    {
        var serviceInstallers = assemblies
                .SelectMany(x => x.DefinedTypes)
                .Where(IsAssignableFrom<IServiceInstaller>)
                .Select(Activator.CreateInstance)
                .Cast<IServiceInstaller>()
                .ToList();

        serviceInstallers.ForEach(service => service.Install(services, configuration));

        return services;
    }

    private static bool IsAssignableFrom<TType>(TypeInfo typeInfo) where TType : class =>
        typeof(TType).IsAssignableFrom(typeInfo) && typeInfo is { IsAbstract: false, IsInterface: false };
}