using System.Collections.ObjectModel;
using DrinkingBuddy.Domain;
using DrinkingBuddy.Entities;
using DrinkingBuddy.Interfaces.Entities;
using DrinkingBuddy.Interfaces.Factories;
using DrinkingBuddy.Interfaces.ViewModels;

namespace DrinkingBuddy.ViewModels;

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
            new DeckCollectionDestination(deckRepo, genericFactory)
        ];
}
