using CardGenerator.Input;
using CardGenerator.Interfaces.Factories;
using CardGenerator.Interfaces.Input;
using CardGenerator.Interfaces.ViewModels.Dialogs;
using MaterialDesignThemes.Wpf;

namespace CardGenerator.ViewModels.Dialogs;

/// <summary>
/// The dialog view model.
/// </summary>
/// <typeparam name="T"/>
public class DialogViewModel<T> : ViewModelBase, IDialogViewModel<T> where T : class
{
    /// <summary>
    /// Constructor for the dialog view model where the result is created when the view model is created.
    /// </summary>
    /// <param name="genericFactory"></param>
    public DialogViewModel(IGenericFactory genericFactory) => Result = genericFactory.Create<T>();

    /// <summary>
    /// Constructor for the dialog view model where the result starts from a given input.
    /// </summary>
    /// <param name="input"></param>
    public DialogViewModel(T input) => Result = input;

    /// <inheritdoc />
    public string ConfirmLabel { get; set; } = "Confirm";

    /// <inheritdoc />
    public T Result { get; }

    /// <inheritdoc />
    public IRelayCommand ConfirmCommand => new RelayCommand(() => DialogHost.Close("RootDialog", Result));

    /// <inheritdoc />
    public IRelayCommand CancelCommand => new RelayCommand(() => DialogHost.Close("RootDialog", null));
}
