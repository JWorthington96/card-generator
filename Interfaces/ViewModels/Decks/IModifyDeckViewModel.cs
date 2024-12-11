using CardGenerator.Interfaces.Input;
using CardGenerator.Interfaces.ViewModels.Cards;

namespace CardGenerator.Interfaces.ViewModels.Decks;

/// <summary>
/// Interface for the modify deck view model.
/// </summary>
public interface IModifyDeckViewModel : IDeckViewModel
{
    /// <summary>
    /// Gets or sets the file path for the image.
    /// </summary>
    string FilePath { get; }

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
