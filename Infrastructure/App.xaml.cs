using System.Windows;
using CardGenerator.Views;
using Microsoft.Extensions.DependencyInjection;

namespace CardGenerator.Infrastructure;

/// <summary>
///     Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var bootstrapper = new Bootstrapper();
        bootstrapper.Start();
        MainWindow = bootstrapper.Host.Services.GetRequiredService<MainWindow>();
        MainWindow.Show();
    }
}
