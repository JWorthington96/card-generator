using DrinkingBuddy.Interfaces.Entities;
using DrinkingBuddy.Interfaces.Factories;
using DrinkingBuddy.ViewModels.Activities;
using MaterialDesignThemes.Wpf;

namespace DrinkingBuddy.Entities;

public class DeckCollectionDestination(IGenericFactory genericFactory) : IDestination<DeckCollectionViewModel>
{
    public DestinationInfo Info => new("Collection", PackIconKind.CardMultiple, PackIconKind.CardMultipleOutline);

    public DeckCollectionViewModel ViewModel => genericFactory.Create<DeckCollectionViewModel>();

    public override string ToString() => Info.ToString();
}
