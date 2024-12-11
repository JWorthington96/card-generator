using CardGenerator.Interfaces.Input;
using CardGenerator.Interfaces.ViewModels.Cards;

namespace CardGenerator.Interfaces.ViewModels.Dialogs;

/// <summary>
/// The modify card view model interface.
/// </summary>
public interface IModifyCardViewModel
{
    /// <summary>
    /// Gets or sets the card.
    /// </summary>
    ICardViewModel Card { get; set; }

    /// <summary>
    /// Gets the select file command.
    /// </summary>
    IRelayCommand SelectFileCommand { get; }
}
