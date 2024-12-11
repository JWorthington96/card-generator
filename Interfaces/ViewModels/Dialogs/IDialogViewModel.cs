using CardGenerator.Interfaces.Input;

namespace CardGenerator.Interfaces.ViewModels.Dialogs;

/// <summary>
/// The dialog view model interface.
/// </summary>
/// <typeparam name="T"/>
public interface IDialogViewModel<T> where T : class
{
    /// <summary>
    /// Gets or sets the label for the confirmation button.
    /// </summary>
    string ConfirmLabel { get; set; }

    /// <summary>
    /// Gets the result of the dialog.
    /// </summary>
    T Result { get; }

    /// <summary>
    /// Gets the confirm command.
    /// </summary>
    IRelayCommand ConfirmCommand { get; }

    /// <summary>
    /// Gets the cancel command.
    /// </summary>
    IRelayCommand CancelCommand { get; }
}
