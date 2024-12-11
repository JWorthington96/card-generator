using System;
using System.Collections.ObjectModel;
using System.Linq;
using CardGenerator.Entities;
using CardGenerator.Interfaces.ViewModels.Cards;
using CardGenerator.Interfaces.ViewModels.Decks;
using CardGenerator.ViewModels.Cards;

namespace CardGenerator.ViewModels.Decks;

/// <summary>
/// The deck view model.
/// </summary>
/// <param name="deck">The deck.</param>
public class DeckViewModel(Deck deck) : ViewModelBase, IDeckViewModel
{
    /// <inheritdoc />
    public ReadOnlyObservableCollection<ICardViewModel> Cards { get; } = new(new ObservableCollection<ICardViewModel>(deck?.Cards.ToArray().Select(CardViewModel.CreateFromCard).ToList() ?? throw new ArgumentNullException(nameof(deck))));

    /// <inheritdoc />
    public string Name { get; } = deck.Name ?? throw new ArgumentNullException(nameof(deck));

    /// <inheritdoc />
    public string Description { get; } = deck.Description ?? throw new ArgumentNullException(nameof(deck));

    /// <inheritdoc />
    public byte[]? ImageThumb { get; } = deck.Image?.ThumbBytes ?? throw new ArgumentNullException(nameof(deck.Image));
}
