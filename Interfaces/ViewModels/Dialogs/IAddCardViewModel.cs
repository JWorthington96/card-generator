using DrinkingBuddy.Entities;
using DrinkingBuddy.Input;

namespace DrinkingBuddy.Interfaces.ViewModels.Dialogs;

public interface IAddCardViewModel
{
    string FlavourText { get; set; }
    ImageData ImageData { get; set; }

    IRelayCommand SelectFileCommand { get; }
    IRelayCommand? AddCommand { get; set; }
    IRelayCommand? CancelCommand { get; set; }
}
