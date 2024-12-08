namespace DrinkingBuddy.Entities;

public class Card
{
    public int Id { get; set; }
    public string Description { get; set; }

    public int DeckId { get; set; }
    public virtual Deck Deck { get; set; }
}
