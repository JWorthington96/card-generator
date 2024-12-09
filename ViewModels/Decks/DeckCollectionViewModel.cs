using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CardGenerator.Domain;
using CardGenerator.Entities;
using CardGenerator.Input;
using CardGenerator.Interfaces.Factories;
using CardGenerator.Interfaces.Input;
using CardGenerator.Interfaces.ViewModels.Decks;

namespace CardGenerator.ViewModels.Decks;

public class DeckCollectionViewModel(IRepository<Deck> deckRepository, IGenericFactory genericFactory) : ViewModelBase, IDeckCollectionViewModel
{
    public IDeckViewModel? CurrentDeck { get; private set; } = null;
    public ObservableCollection<Deck> Decks => new(deckRepository.GetAllAsync().Result!);

    public IRelayCommand AddCommand => new RelayCommand(() => CreateDeckViewModel(new Deck()));

    public IAsyncRelayCommand<int> EditCommand => new AsyncRelayCommand<int>(EditDeckAsync);

    public IAsyncRelayCommand<int> DeleteCommand => new AsyncRelayCommand<int>(DeleteDeckAsync);

    private async Task EditDeckAsync(int id)
    {
        var deck = await deckRepository.GetByIdAsync(id);
        CreateDeckViewModel(deck);
    }

    private async Task DeleteDeckAsync(int id) => await deckRepository.DeleteByIdAsync(id);

    private void CreateDeckViewModel(Deck deck)
    {
        CurrentDeck = genericFactory.Create<DeckViewModel>(deck);
        CurrentDeck.SaveCommand = new AsyncRelayCommand(() => SaveDeck(deck));
        CurrentDeck.CancelCommand = new RelayCommand(Cancel);

        OnPropertyChanged(nameof(CurrentDeck));
    }

    private async Task SaveDeck(Deck deck)
    {
        // update cards
        foreach (var card in CurrentDeck!.Cards.Where(card => card.IsModified))
        {
            var existing = deck.Cards.FirstOrDefault(c => c.Id == card.Id);
            var newCard = new Card() { Description = card.FlavourText, Image = card.ImageData, DeckId = deck.Id, Deck = deck };
            if (existing is not null)
            {
                deck.Cards.Remove(existing);
                newCard.Id = card.Id;
            }
            deck.Cards.Add(newCard);
        }
        // add new cards
        foreach (var card in CurrentDeck!.Cards.Where(card => !deck.Cards.Select(c => c.Id).Contains(card.Id)))
        {
            deck.Cards.Add(new Card() { Description = card.FlavourText, Image = card.ImageData, DeckId = deck.Id, Deck = deck });
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
