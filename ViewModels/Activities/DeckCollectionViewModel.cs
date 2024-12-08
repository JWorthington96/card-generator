using System.Collections.ObjectModel;
using System.Threading.Tasks;
using DrinkingBuddy.Domain;
using DrinkingBuddy.Entities;
using DrinkingBuddy.Input;
using DrinkingBuddy.Interfaces.Factories;
using DrinkingBuddy.Interfaces.ViewModels.Activities;

namespace DrinkingBuddy.ViewModels.Activities;

public class DeckCollectionViewModel(IRepository<Deck> deckRepository, IRepository<Card> cardRepository, IGenericFactory genericFactory) : ViewModelBase, IDeckCollectionViewModel
{
    public IDeckViewModel? CurrentDeck { get; private set; } = null;
    public ObservableCollection<Deck> Decks => new(deckRepository.GetAllAsync().Result!);

    public IRelayCommand AddCommand => new RelayCommand(() => CreateDeckViewModel(new Deck()));

    public IAsyncRelayCommand<int> EditCommand => new AsyncRelayCommand<int>(EditDeckAsync);

    private async Task EditDeckAsync(int id)
    {
        var deck = await deckRepository.GetByIdAsync(id);
        CreateDeckViewModel(deck);
    }

    private void CreateDeckViewModel(Deck deck)
    {
        CurrentDeck = genericFactory.Create<DeckViewModel>(deck);
        CurrentDeck.SaveCommand = new AsyncRelayCommand(() => SaveDeck(deck));
        CurrentDeck.CancelCommand = new RelayCommand(Cancel);

        OnPropertyChanged(nameof(CurrentDeck));
    }

    private async Task SaveDeck(Deck deck)
    {
        foreach (var card in deck.Cards)
        {
            await cardRepository.AddOrUpdateAsync(card);
        }
        await deckRepository.AddOrUpdateAsync(deck);
        CurrentDeck = null;
        OnPropertyChanged(nameof(Decks));
        OnPropertyChanged(nameof(CurrentDeck));
    }

    private void Cancel()
    {
        CurrentDeck?.SaveCommand?.Cancel();
        CurrentDeck = null;
        OnPropertyChanged(nameof(CurrentDeck));
    }
}
