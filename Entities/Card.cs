using System.Diagnostics.CodeAnalysis;

namespace CardGenerator.Entities;

/// <summary>
/// The database object for a card.
/// </summary>
public class Card : DbEntity
{

    /// <summary>
    /// Gets or sets the flavour text.
    /// </summary>
    [MaybeNull]
    public string FlavourText { get; set; }


    /// <summary>
    /// Gets or sets the id of the deck that owns the card.
    /// </summary>
    public int DeckId { get; set; }


    /// <summary>
    /// Gets or sets the deck that owns the card.
    /// </summary>
    [MaybeNull]
    public virtual Deck Deck { get; set; }


    /// <summary>
    /// Gets or sets the image on the card.
    /// </summary>
    [MaybeNull]
    public virtual ImageData Image { get; set; }
}
