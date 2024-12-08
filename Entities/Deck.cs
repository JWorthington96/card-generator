namespace DrinkingBuddy.Entities;

public readonly struct Deck(int id, string name, string description)
{
    public int Id { get; } = id;
    public string Name { get; } = name;
    public string Description { get; } = description;
}
