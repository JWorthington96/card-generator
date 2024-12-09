using CardGenerator.Input;
using CardGenerator.Interfaces.Factories;
using CardGenerator.Interfaces.Input;
using CardGenerator.Interfaces.ViewModels.Dialogs;
using MaterialDesignThemes.Wpf;

namespace CardGenerator.ViewModels.Dialogs;

public class DialogViewModel<T>(IGenericFactory genericFactory, T? input = null) : ViewModelBase, IDialogViewModel<T> where T : class
{
    public string ConfirmLabel { get; set; } = "Confirm";

    public T Result { get; set; } = input ?? genericFactory.Create<T>();
    public IRelayCommand ConfirmCommand => new RelayCommand(() => DialogHost.Close("RootDialog", Result));
    public IRelayCommand CancelCommand => new RelayCommand(() => DialogHost.Close("RootDialog", null));
}
