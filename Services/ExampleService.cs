using System.Diagnostics;
using WpfAppBase.Interfaces.Services;

namespace WpfAppBase.Services;

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
