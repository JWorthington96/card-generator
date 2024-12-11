using System.Collections.ObjectModel;
using CardGenerator.Interfaces.ViewModels.Cards;

namespace CardGenerator.Interfaces.ViewModels.Decks;

/// <summary>
/// The deck view model interface.
/// </summary>
public interface IDeckViewModel
{
    /// <summary>
    /// Gets the cards.
    /// </summary>
    ReadOnlyObservableCollection<ICardViewModel> Cards { get; }

    /// <summary>
    /// Gets the deck name.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Gets or sets the deck description.
    /// </summary>
    string Description { get; }

    /// <summary>
    /// Gets the byte array for the image thumbnail.
    /// </summary>
    byte[]? ImageThumb { get; }
}
