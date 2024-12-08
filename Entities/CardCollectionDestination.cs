using DrinkingBuddy.Interfaces.Entities;
using DrinkingBuddy.Interfaces.Services;
using DrinkingBuddy.ViewModels.Activities;
using MaterialDesignThemes.Wpf;

namespace DrinkingBuddy.Entities;

public class CardCollectionDestination(IExampleService exampleService) : IDestination<CardCollectionViewModel>
{
    public DestinationInfo Info => new("Collection", PackIconKind.CardMultiple, PackIconKind.CardMultipleOutline);

    public CardCollectionViewModel ViewModel => new(exampleService);

    public override string ToString() => Info.ToString();
}
