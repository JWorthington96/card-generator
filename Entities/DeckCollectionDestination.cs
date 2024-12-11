using CardGenerator.Interfaces.Entities;
using CardGenerator.Interfaces.Factories;
using CardGenerator.ViewModels.Decks;
using MaterialDesignThemes.Wpf;

namespace CardGenerator.Entities;

/// <summary>
/// The deck collection navigation rail destination.
/// </summary>
/// <param name="genericFactory"> A generic factory. </param>
/// <seealso cref="IDestination{ExportViewModel}"/>
public class DeckCollectionDestination(IGenericFactory genericFactory) : IDestination<DeckCollectionViewModel>
{
    /// <inheritdoc />
    public DestinationInfo Info => new("Collection", PackIconKind.CardMultiple, PackIconKind.CardMultipleOutline);

    /// <inheritdoc />
    public DeckCollectionViewModel ViewModel => genericFactory.Create<DeckCollectionViewModel>();

    /// <inheritdoc />
    public override string ToString() => Info.ToString();
}
