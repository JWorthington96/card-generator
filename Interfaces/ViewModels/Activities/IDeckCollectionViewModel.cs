using System.Collections.ObjectModel;
using DrinkingBuddy.Entities;
using DrinkingBuddy.Input;

namespace DrinkingBuddy.Interfaces.ViewModels.Activities;

public interface IDeckCollectionViewModel
{
    IDeckViewModel? CurrentDeck { get; }

    public ObservableCollection<Deck> Decks { get; }

    IRelayCommand AddCommand { get; }
    IAsyncRelayCommand<int> EditCommand { get; }
}
