using CardGenerator.ViewModels;

namespace CardGenerator.Interfaces.ViewModels;

/// <summary>
///     The interface for the main window view model.
/// </summary>
public interface IMainWindowViewModel
{
    /// <summary>
    ///     The current destination from the navigation rail.
    /// </summary>
    ViewModelBase? CurrentDestination { get; set; }
}
