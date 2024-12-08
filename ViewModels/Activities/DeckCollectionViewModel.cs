using DrinkingBuddy.Entities;
using DrinkingBuddy.Interfaces.ViewModels.Activities;
using System.Collections.ObjectModel;

namespace DrinkingBuddy.ViewModels.Activities;

public class DeckCollectionViewModel : ViewModelBase, IDeckCollectionViewModel
{
    public ObservableCollection<Deck> Decks { get; } =
        [
        new Deck(1, "Deck1", "This is a test deck."),
        new Deck(2, "Deck2", "This is another test deck."),
        new Deck(3, "Deck3", "This is yet another test deck.")
        ];
}
