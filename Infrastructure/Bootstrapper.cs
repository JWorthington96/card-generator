using CardGenerator.Domain;
using CardGenerator.Entities;
using CardGenerator.Interfaces.Factories;
using CardGenerator.Interfaces.Services;
using CardGenerator.Interfaces.ViewModels;
using CardGenerator.Interfaces.ViewModels.Cards;
using CardGenerator.Interfaces.ViewModels.Decks;
using CardGenerator.Interfaces.ViewModels.Dialogs;
using CardGenerator.Services;
using CardGenerator.ViewModels;
using CardGenerator.ViewModels.Cards;
using CardGenerator.ViewModels.Decks;
using CardGenerator.ViewModels.Dialogs;
using CardGenerator.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CardGenerator.Infrastructure;

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
        services.AddScoped<IPdfExportService, PdfExportService>();

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

        // Repositories
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<CardRepository>();

        // Factories
        services.AddScoped<IGenericFactory, GenericFactory>(serviceProvider => new GenericFactory(serviceProvider));

        // View Models
        services.AddSingleton<IMainWindowViewModel, MainWindowViewModel>();
        services.AddSingleton<INavigationRailViewModel, NavigationRailViewModel>();
        services.AddScoped<IDeckCollectionViewModel, DeckCollectionViewModel>();
        services.AddTransient<IDeckViewModel, DeckViewModel>();
        services.AddTransient<ICardViewModel, CardViewModel>();

        services.AddTransient<Font>();
        services.AddTransient(typeof(IDialogViewModel<>), typeof(DialogViewModel<>));
        services.AddTransient<IModifyCardViewModel, ModifyCardViewModel>();
        services.AddTransient<IExportOptionsViewModel, ExportOptionsViewModel>();

        // Views
        services.AddSingleton<MainWindow>();
    }
}

