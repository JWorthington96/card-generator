using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CardGenerator.Entities;

public class Deck : DbEntry
{
    public string Name { get; set; }
    public string Description { get; set; }

    public virtual ImageData Image { get; set; }
    public virtual ICollection<Card> Cards { get; private set; } = new ObservableCollection<Card>();

    public override string ToString() => Name;
}
