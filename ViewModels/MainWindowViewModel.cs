using CardGenerator.Interfaces.ViewModels;

namespace CardGenerator.ViewModels;

/// <summary>
///     The main window view model.
/// </summary>
public sealed class MainWindowViewModel(INavigationRailViewModel navigationRailViewModel) : ViewModelBase, IMainWindowViewModel
{
    public INavigationRailViewModel NavigationRailViewModel => navigationRailViewModel;

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

