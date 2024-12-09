using CardGenerator.Interfaces.Input;
using CardGenerator.Interfaces.ViewModels.Cards;

namespace CardGenerator.Interfaces.ViewModels.Dialogs;

public interface IModifyCardViewModel
{
    ICardViewModel Card { get; set; }

    IRelayCommand SelectFileCommand { get; }
}
