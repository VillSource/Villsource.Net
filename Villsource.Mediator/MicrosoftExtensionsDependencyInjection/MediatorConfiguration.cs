using System.Reflection;

namespace Villsource.Mediator.MicrosoftExtensionsDependencyInjection;

public class MediatorConfiguration
{
    public IEnumerable<Assembly> AssembliesToScan { get; set; } = [];
}