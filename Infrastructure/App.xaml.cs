using System.Windows;
using DrinkingBuddy.Domain;
using DrinkingBuddy.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DrinkingBuddy.Infrastructure;

/// <summary>
///     Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private IHost host;
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var bootstrapper = new Bootstrapper();
        bootstrapper.Start();
        host = bootstrapper.Host;
        MainWindow = bootstrapper.Host.Services.GetRequiredService<MainWindow>();
        MainWindow.Show();
    }

    protected override void OnExit(ExitEventArgs e)
    {
        if (host is not null)
        {
            var context = host.Services.GetRequiredService<DeckContext>();
            context.Database.EnsureDeleted();
        }

        base.OnExit(e);
    }
}
