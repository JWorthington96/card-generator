using DrinkingBuddy.Domain;
using DrinkingBuddy.Interfaces.Factories;
using DrinkingBuddy.Interfaces.Services;
using DrinkingBuddy.Interfaces.ViewModels;
using DrinkingBuddy.Interfaces.ViewModels.Activities;
using DrinkingBuddy.Services;
using DrinkingBuddy.ViewModels;
using DrinkingBuddy.ViewModels.Activities;
using DrinkingBuddy.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DrinkingBuddy.Infrastructure;

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

        // Domain
        services.AddScoped<DeckContext>();
        services.AddDbContext<DeckContext>();

        //services.AddDbContext<DeckContext>(options =>
        //{
        //    options.UseSqlServer(
        //        builder.Configuration.GetConnectionString("DefaultConnection"),
        //        sqlServerOptionsAction: sqlOptions =>
        //        {
        //            sqlOptions.MigrationsAssembly("Plutus.ProductPricing.DataAccess");
        //        });
        //});

        // Generics
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped(typeof(IGenericFactory), typeof(GenericFactory));

        // View Models
        services.AddSingleton<IMainWindowViewModel, MainWindowViewModel>();
        services.AddSingleton<INavigationRailViewModel, NavigationRailViewModel>();
        services.AddSingleton<IDeckViewModel, DeckViewModel>();
        services.AddSingleton<IDeckCollectionViewModel, DeckCollectionViewModel>();

        // Views
        services.AddSingleton<MainWindow>();
    }
}

