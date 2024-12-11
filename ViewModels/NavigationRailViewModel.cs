using System.Collections.ObjectModel;
using CardGenerator.Entities;
using CardGenerator.Interfaces.Entities;
using CardGenerator.Interfaces.Factories;
using CardGenerator.Interfaces.ViewModels;

namespace CardGenerator.ViewModels;


/// <summary>
/// The navigation rail view model.
/// </summary>
/// <param name="genericFactory">The generic factory.</param>
public class NavigationRailViewModel(IGenericFactory genericFactory) : ViewModelBase, INavigationRailViewModel
{
    private IDestination<ViewModelBase>? selectedDestination;
    /// <inheritdoc/>
    public IDestination<ViewModelBase>? SelectedDestination
    {
        get => selectedDestination;
        set
        {
            selectedDestination = value;
            OnPropertyChanged();
        }
    }

    /// <inheritdoc/>
    public ObservableCollection<IDestination<ViewModelBase>> Destinations { get; } =
        [
            genericFactory.Create<DeckCollectionDestination>(),
            genericFactory.Create<ExportDestination>()
        ];
}
