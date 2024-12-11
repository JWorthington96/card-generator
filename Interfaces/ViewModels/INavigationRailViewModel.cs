using System.Collections.ObjectModel;
using CardGenerator.Interfaces.Entities;
using CardGenerator.ViewModels;

namespace CardGenerator.Interfaces.ViewModels;

/// <summary>
/// The navigation rail view model interface.
/// </summary>
public interface INavigationRailViewModel
{
    /// <summary>
    /// The currently selected destination. Is null if none is selected.
    /// </summary>
    IDestination<ViewModelBase>? SelectedDestination { get; }

    /// <summary>
    /// Gets the navigation rail destinations.
    /// </summary>
    ObservableCollection<IDestination<ViewModelBase>> Destinations { get; }
}
