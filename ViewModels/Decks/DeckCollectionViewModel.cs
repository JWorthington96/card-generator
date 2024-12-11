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

/// <summary>
/// The deck collection view model.
/// </summary>
/// <param name="deckRepository">The deck repository.</param>
/// <param name="genericFactory">The generic factory.</param>
public class DeckCollectionViewModel(IRepository<Deck> deckRepository, IGenericFactory genericFactory) : ViewModelBase, IDeckCollectionViewModel
{
    /// <inheritdoc />
    public IModifyDeckViewModel? CurrentDeck { get; private set; } = null;

    /// <inheritdoc />
    public ObservableCollection<Deck> Decks => new(deckRepository.GetAllAsync().Result!);

    /// <inheritdoc />
    public IRelayCommand AddCommand => new RelayCommand(() => CreateDeckViewModel(new Deck()));

    /// <inheritdoc />
    public IAsyncRelayCommand<int> EditCommand => new AsyncRelayCommand<int>(EditDeckAsync);

    /// <inheritdoc />
    public IAsyncRelayCommand<int> DeleteCommand => new AsyncRelayCommand<int>(DeleteDeckAsync);

    private async Task EditDeckAsync(int id)
    {
        var deck = await deckRepository.GetByIdAsync(id);
        if (deck is null) return;

        CreateDeckViewModel(deck);
    }

    private async Task DeleteDeckAsync(int id) => await deckRepository.DeleteByIdAsync(id);

    private void CreateDeckViewModel(Deck deck)
    {
        CurrentDeck = genericFactory.Create<ModifyDeckViewModel>(deck, () => Cancel(), () => SaveDeck(deck));

        OnPropertyChanged(nameof(CurrentDeck));
    }

    private async Task SaveDeck(Deck deck)
    {
        // update cards
        foreach (var card in CurrentDeck!.Cards.Where(card => card.IsModified))
        {
            var existing = deck.Cards.FirstOrDefault(c => c.Id == card.Id);
            var newCard = new Card() { FlavourText = card.FlavourText, Image = card.Image, DeckId = deck.Id, Deck = deck };
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
            deck.Cards.Add(new Card() { FlavourText = card.FlavourText, Image = card.Image, DeckId = deck.Id, Deck = deck });
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
