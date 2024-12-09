using CardGenerator.Interfaces.Input;

namespace CardGenerator.Interfaces.ViewModels.Dialogs;

public interface IDialogViewModel<T> where T : class
{
    string ConfirmLabel { get; set; }

    T Result { get; set; }
    IRelayCommand ConfirmCommand { get; }
    IRelayCommand CancelCommand { get; }
}
