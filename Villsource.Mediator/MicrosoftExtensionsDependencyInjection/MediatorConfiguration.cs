using System.Reflection;
using Villsource.Mediator.Abstractions;
using ICommand = System.Windows.Input.ICommand;

// ReSharper disable CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public class MediatorConfiguration
{
    public IEnumerable<Assembly> AssembliesToScan { get; set; } = [Assembly.GetExecutingAssembly()];
}