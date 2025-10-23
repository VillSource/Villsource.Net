using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Villsource.Mediator.MicrosoftExtensionsDependencyInjection;

public static class MediatorServicesExtension
{
    public static IServiceCollection AddMediator(this IServiceCollection services, Action<MediatorConfiguration> config)
    {
        var configuration = new MediatorConfiguration();
        config(configuration);
        return services.AddMediator(configuration);
    }
    public static IServiceCollection AddMediator(this IServiceCollection services, MediatorConfiguration config)
    {
        
        return services;
    }
    
    private static void RegisterHandlers(this IServiceCollection services, Assembly[] assembly, params Type[] openGenericInterface )
    {
        // Find all concrete classes in the assembly that implement the specified open generic interface
        var implementationTypes = assembly.SelectMany(asm => asm.GetTypes())
            .Where(t => !t.IsAbstract && !t.IsInterface && t.IsGenericType )
            .ToList();
        
        foreach (var implType in implementationTypes)
        {
            // Find the specific closed generic interface(s) the class implements
            var serviceInterfaces = implType.GetInterfaces()
                .Where(i => i.IsGenericType && openGenericInterface.Contains(i.GetGenericTypeDefinition()));

            foreach (var serviceInterface in serviceInterfaces)
            {
                // Register the class with its corresponding interface
                services.AddScoped(serviceInterface, implType);
            }
        }
    }
}