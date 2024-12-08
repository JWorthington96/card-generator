using DrinkingBuddy.Interfaces.Entities;
using DrinkingBuddy.Interfaces.Factories;
using DrinkingBuddy.ViewModels.Activities;
using MaterialDesignThemes.Wpf;

namespace DrinkingBuddy.Entities;

public class CardCollectionDestination(IGenericFactory genericFactory) : IDestination<DeckViewModel>
{
    public DestinationInfo Info => new("Collection", PackIconKind.CardMultiple, PackIconKind.CardMultipleOutline);

    public DeckViewModel ViewModel => genericFactory.Create<DeckViewModel>();

    public override string ToString() => Info.ToString();
}
