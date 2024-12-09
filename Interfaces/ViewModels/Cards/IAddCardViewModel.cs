using CardGenerator.Interfaces.Input;

namespace CardGenerator.Interfaces.ViewModels.Cards;

public interface IAddCardViewModel<T> where T : ICardViewModel
{
    T Card { get; }

    string ConfirmLabel { get; set; }

    IRelayCommand SelectFileCommand { get; }
    IRelayCommand ConfirmCommand { get; }
    IRelayCommand CancelCommand { get; }
}
