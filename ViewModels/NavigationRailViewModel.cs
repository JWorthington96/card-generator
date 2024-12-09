using System.Collections.ObjectModel;
using CardGenerator.Domain;
using CardGenerator.Entities;
using CardGenerator.Interfaces.Entities;
using CardGenerator.Interfaces.Factories;
using CardGenerator.Interfaces.ViewModels;

namespace CardGenerator.ViewModels;

public class NavigationRailViewModel(IGenericFactory genericFactory, IRepository<Deck> deckRepo) : ViewModelBase, INavigationRailViewModel
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

    public ObservableCollection<IDestination<ViewModelBase>> Destinations { get; } =
        [
            genericFactory.Create<DeckCollectionDestination>(),
            genericFactory.Create<ExportDestination>()
        ];
}
