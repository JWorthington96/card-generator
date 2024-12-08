using DrinkingBuddy.Interfaces.Services;
using DrinkingBuddy.ViewModels;
using DrinkingBuddy.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace DrinkingBuddy.Infrastructure;

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

        MainWindow = new MainWindow
        {
            DataContext = new MainWindowViewModel(bootstrapper.Host.Services.GetService<IExampleService>()!)
        };
        MainWindow.Show();
    }
}
