using System.Collections.ObjectModel;
using CardGenerator.Interfaces.Input;
using CardGenerator.Interfaces.ViewModels.Cards;

namespace CardGenerator.Interfaces.ViewModels.Decks;

/// <summary>
/// Interface for the deck view model.
/// </summary>
public interface IDeckViewModel
{
    /// <summary>
    /// Gets the cards.
    /// </summary>
    ReadOnlyObservableCollection<ICardViewModel> Cards { get; }

    /// <summary>
    /// Gets the deck name.
    /// </summary>
    string Name { get; set; }

    /// <summary>
    /// Gets or sets the deck description.
    /// </summary>
    string Description { get; set; }

    /// <summary>
    /// Gets or sets the file path for the image.
    /// </summary>
    string FilePath { get; set; }

    /// <summary>
    /// Gets the byte array for the image thumbnail.
    /// </summary>
    byte[]? ImageThumb { get; }

    /// <summary>
    /// Gets the add card command.
    /// </summary>
    IAsyncRelayCommand AddCardCommand { get; }

    /// <summary>
    /// Gets the edit card command.
    /// </summary>
    IAsyncRelayCommand<ICardViewModel> EditCardCommand { get; }

    /// <summary>
    /// Gets the delete card command.
    /// </summary>
    IRelayCommand<ICardViewModel> DeleteCardCommand { get; }

    /// <summary>
    /// Gets the save command.
    /// </summary>
    IAsyncRelayCommand SaveCommand { get; }

    /// <summary>
    /// Gets the cancel command.
    /// </summary>
    IRelayCommand CancelCommand { get; }
}
