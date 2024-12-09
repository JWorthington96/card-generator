using System.Collections.ObjectModel;
using CardGenerator.Interfaces.Input;
using CardGenerator.Interfaces.ViewModels.Cards;

namespace CardGenerator.Interfaces.ViewModels.Decks;

/// <summary>
///     Interface for the deck view model.
/// </summary>
public interface IDeckViewModel
{
    ReadOnlyObservableCollection<ICardViewModel> Cards { get; }

    string Name { get; set; }
    string Description { get; set; }
    string FilePath { get; set; }
    byte[]? ImageThumb { get; }


    IAsyncRelayCommand AddCardCommand { get; }
    IAsyncRelayCommand<ICardViewModel> EditCardCommand { get; }
    IRelayCommand<ICardViewModel> DeleteCardCommand { get; }

    IAsyncRelayCommand? SaveCommand { get; set; }
    IRelayCommand? CancelCommand { get; set; }
}
