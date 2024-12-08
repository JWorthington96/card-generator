using DrinkingBuddy.Entities;
using DrinkingBuddy.Interfaces.Entities;
using DrinkingBuddy.Interfaces.Services;
using DrinkingBuddy.Interfaces.ViewModels;
using System.Collections.ObjectModel;

namespace DrinkingBuddy.ViewModels;

public class NavigationRailViewModel(IExampleService exampleService) : ViewModelBase, INavigationRailViewModel
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
            new DeckCollectionDestination()
        ];
}
