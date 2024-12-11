using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;

namespace CardGenerator.Entities;

/// <summary>
/// The database object for a deck.
/// </summary>
public class Deck : DbEntity
{
    /// <summary>
    /// Gets or sets the name of the deck.
    /// </summary>
    [MaybeNull]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the description of the deck.
    /// </summary>
    [MaybeNull]
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the image for the deck.
    /// </summary>
    [MaybeNull]
    public virtual ImageData Image { get; set; }

    /// <summary>
    /// Gets the cards in the deck.
    /// </summary>
    public virtual ICollection<Card> Cards { get; private set; } = new ObservableCollection<Card>();

    /// <inheritdoc />
    public override string ToString() => Name ?? nameof(Deck);
}
