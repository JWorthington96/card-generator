namespace DrinkingBuddy.Entities;

public class Card : DbEntry
{
    public string Description { get; set; }

    public int DeckId { get; set; }
    public virtual Deck Deck { get; set; }
    public virtual ImageData Image { get; set; }
}
