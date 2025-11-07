using System.Reflection;

namespace Villsource.Mediator.MicrosoftExtensionsDI;

public class VillsourceMediatorConfiguration
{
    public IEnumerable<Assembly> AssembliesToRegister { get; set; } = AppDomain.CurrentDomain.GetAssemblies();
}