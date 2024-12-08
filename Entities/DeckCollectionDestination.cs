using DrinkingBuddy.Interfaces.Entities;
using DrinkingBuddy.ViewModels.Activities;
using MaterialDesignThemes.Wpf;

namespace DrinkingBuddy.Entities;

public class DeckCollectionDestination : IDestination<DeckCollectionViewModel>
{
    public DestinationInfo Info => new("Collection", PackIconKind.CardMultiple, PackIconKind.CardMultipleOutline);

    public DeckCollectionViewModel ViewModel => new();

    public override string ToString() => Info.ToString();
}
