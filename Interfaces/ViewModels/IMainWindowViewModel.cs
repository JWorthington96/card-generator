using CardGenerator.ViewModels;

namespace CardGenerator.Interfaces.ViewModels;

/// <summary>
/// The interface for the main window view model.
/// </summary>
public interface IMainWindowViewModel
{
    /// <summary>
    /// An instance of navigation rail view model.
    /// </summary>
    INavigationRailViewModel NavigationRailViewModel { get; }

    /// <summary>
    /// The current destination from the navigation rail.
    /// </summary>
    ViewModelBase? CurrentDestination { get; set; }
}
