using WpfAppBase.ViewModels;

namespace WpfAppBase.Interfaces.ViewModels;

/// <summary>
///     The interface for the main window view model.
/// </summary>
public interface IMainWindowViewModel
{
    /// <summary>
    ///     The activity view model being displayed.
    /// </summary>
    ViewModelBase? ActivityViewModel { get; set; }
}
