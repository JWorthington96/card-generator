using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WpfAppBase.Interfaces.Services;
using WpfAppBase.Services;

namespace WpfAppBase.Infrastructure;

/// <summary>
///     Responsible for creating the application builder, and registering all of the dependencies used in dependency injection and configuration.
/// </summary>
public class Bootstrapper
{
    /// <summary>
    ///     Constructor for the bootstrapper.
    /// </summary>
    public Bootstrapper()
    {
        Host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
            .ConfigureServices((_, services) => RegisterServices(services))
            .Build();
    }

    public IHost Host { get; init; }

    /// <summary>
    ///     Runs the host for dependency injection and configuration.
    /// </summary>
    public void Start() => Host.RunAsync();

    // Register services for dependency injection here
    private static void RegisterServices(IServiceCollection services)
    {
        // Services
        services.AddScoped<IExampleService, ExampleService>();
    }
}

