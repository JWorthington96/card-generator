using CardGenerator.Interfaces.Input;
using CardGenerator.Interfaces.ViewModels.Cards;

namespace CardGenerator.Interfaces.ViewModels.Dialogs;

/// <summary>
/// The modify card view model interface.
/// </summary>
public interface IModifyCardViewModel : IDialogViewModel<ICardViewModel>
{
    /// <summary>
    /// Gets the select file command.
    /// </summary>
    IRelayCommand SelectFileCommand { get; }
}
