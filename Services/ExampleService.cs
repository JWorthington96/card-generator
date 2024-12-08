using System.Diagnostics;
using DrinkingBuddy.Interfaces.Services;

namespace DrinkingBuddy.Services;

/// <summary>
///     An example class for DI.
/// </summary>
public class ExampleService : IExampleService
{
    /// <inheritdoc/>
    public void ExampleMethod()
    {
        Debug.WriteLine("Example method called");
    }
}
