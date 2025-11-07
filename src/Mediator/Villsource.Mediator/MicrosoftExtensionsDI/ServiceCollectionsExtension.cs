// ReSharper disable CheckNamespace

using System.Reflection;
using System.Runtime.CompilerServices;
using Villsource.Mediator;
using Villsource.Mediator.Abstractions;
using Villsource.Mediator.MicrosoftExtensionsDI;

namespace Microsoft.Extensions.DependencyInjection;

public  static class ServiceCollectionsExtension
{
    public static IServiceCollection AddVillsourceMediator(this IServiceCollection services, Action<VillsourceMediatorConfiguration>? options = null)
    {
        var configuration = new VillsourceMediatorConfiguration();
        options?.Invoke(configuration);
        return services.AddVillsourceMediator(configuration);
    }
    public static IServiceCollection AddVillsourceMediator(this IServiceCollection services, VillsourceMediatorConfiguration configuration)
    {
        services.AddScoped<IMediator, Mediator>();
        services.AddRequestHandlers(configuration.AssembliesToRegister);
        return services;
    }
    
    
    
    
    // HELPER
    private static IServiceCollection AddRequestHandlers(
        this IServiceCollection services, 
        params IEnumerable<Assembly> assembliesToScan)
    {
        var openGenericInterface = typeof(IRequestHandler<,>);

        var registrations = assembliesToScan
            .SelectMany(assembly => assembly.GetTypes()) 
            .Where(type => type is { IsAbstract: false, IsGenericTypeDefinition: false, IsInterface:false })
            .Select(type => new 
            {
                ImplementationType = type,
                ServiceTypes = type.GetInterfaces()
                    .Where(i => i.IsGenericType && 
                                i.GetGenericTypeDefinition() == openGenericInterface)
            })
            .Where(reg => reg.ServiceTypes.Any()); 

        foreach (var reg in registrations)
        {
            foreach (var serviceType in reg.ServiceTypes)
            {
                services.AddScoped(serviceType, reg.ImplementationType);
            }
        }

        return services;
    }
}