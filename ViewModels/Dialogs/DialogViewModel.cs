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
/// <param name="genericFactory">The generic factory.</param>
/// <param name="input">The input.</param>
public class DialogViewModel<T>(IGenericFactory genericFactory, T? input = null) : ViewModelBase, IDialogViewModel<T> where T : class
{
    /// <inheritdoc />
    public string ConfirmLabel { get; set; } = "Confirm";

    /// <inheritdoc />
    public T Result { get; } = input ?? genericFactory.Create<T>();

    /// <inheritdoc />
    public IRelayCommand ConfirmCommand => new RelayCommand(() => DialogHost.Close("RootDialog", Result));

    /// <inheritdoc />
    public IRelayCommand CancelCommand => new RelayCommand(() => DialogHost.Close("RootDialog", null));
}
