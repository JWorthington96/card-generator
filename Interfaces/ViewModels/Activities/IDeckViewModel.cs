using System.Collections.ObjectModel;
using DrinkingBuddy.Entities;
using DrinkingBuddy.Input;

namespace DrinkingBuddy.Interfaces.ViewModels.Activities;

/// <summary>
///     Interface for the deck view model.
/// </summary>
public interface IDeckViewModel
{
    string Name { get; set; }
    string Description { get; set; }
    string FilePath { get; set; }
    byte[]? ImageThumb { get; }

    ObservableCollection<Card> Cards { get; }

    IAsyncRelayCommand AddCardCommand { get; }
    IAsyncRelayCommand? SaveCommand { get; set; }
    IRelayCommand? CancelCommand { get; set; }
}
