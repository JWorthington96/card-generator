using DrinkingBuddy.Interfaces.Services;
using DrinkingBuddy.Interfaces.ViewModels;

namespace DrinkingBuddy.ViewModels;

/// <summary>
///     The main window view model.
/// </summary>
public sealed class MainWindowViewModel(IExampleService exampleService) : ViewModelBase, IMainWindowViewModel
{
    public NavigationRailViewModel NavigationRailViewModel => new(exampleService);

    ViewModelBase? currentDestination;
    /// <inheritdoc/>
    public ViewModelBase? CurrentDestination
    {
        get => currentDestination;
        set
        {
            currentDestination = value;
            OnPropertyChanged();
        }
    }
}

