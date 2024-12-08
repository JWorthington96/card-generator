using System.Collections.ObjectModel;
using DrinkingBuddy.Domain;
using DrinkingBuddy.Entities;
using DrinkingBuddy.Input;
using DrinkingBuddy.Interfaces.Input;
using DrinkingBuddy.Interfaces.ViewModels.Activities;

namespace DrinkingBuddy.ViewModels.Activities;

public class DeckCollectionViewModel(IRepository<Deck> deckRepository) : ViewModelBase, IDeckCollectionViewModel
{
    public ObservableCollection<Deck> Decks => new(deckRepository.GetAllAsync().Result!);

    public IRelayCommand AddCommand => new RelayCommand(CreateDeckAndRefresh);

    private async void CreateDeckAndRefresh()
    {
        await deckRepository.AddAsync(new Deck() { Name = "TestDeck", Description = "TestDescription" });
        OnPropertyChanged(nameof(Decks));
    }
}
