using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DrinkingBuddy.Entities;

public class Deck
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public virtual ICollection<Card> Cards { get; private set; } = new ObservableCollection<Card>();
}
