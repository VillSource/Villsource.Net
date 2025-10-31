using System.Reflection;

// ReSharper disable CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class MediatorServicesExtension
{
    public static IServiceCollection AddVillsourceMediator(this IServiceCollection services, Action<MediatorConfiguration> config)
    {
        var configuration = new MediatorConfiguration();
        config(configuration);
        return services.AddVillsourceMediator(configuration);
    }
    public static IServiceCollection AddVillsourceMediator(this IServiceCollection services, MediatorConfiguration config)
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