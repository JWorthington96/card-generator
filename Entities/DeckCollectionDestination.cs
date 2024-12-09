using CardGenerator.Interfaces.Entities;
using CardGenerator.Interfaces.Factories;
using CardGenerator.ViewModels.Decks;
using MaterialDesignThemes.Wpf;

namespace CardGenerator.Entities;

public class DeckCollectionDestination(IGenericFactory genericFactory) : IDestination<DeckCollectionViewModel>
{
    public DestinationInfo Info => new("Collection", PackIconKind.CardMultiple, PackIconKind.CardMultipleOutline);

    public DeckCollectionViewModel ViewModel => genericFactory.Create<DeckCollectionViewModel>();

    public override string ToString() => Info.ToString();
}
