using System.Collections.ObjectModel;
using CardGenerator.Entities;
using CardGenerator.Interfaces.Input;

namespace CardGenerator.Interfaces.ViewModels.Decks;

/// <summary>
/// The deck collection view model.
/// </summary>
public interface IDeckCollectionViewModel
{
    /// <summary>
    /// Gets the current deck.
    /// </summary>
    IDeckViewModel? CurrentDeck { get; }

    /// <summary>
    /// Gets the current deck.
    /// </summary>
    public ObservableCollection<Deck> Decks { get; }

    /// <summary>
    /// Gets the add command.
    /// </summary>
    IRelayCommand AddCommand { get; }

    /// <summary>
    /// Gets the edit command.
    /// </summary>
    IAsyncRelayCommand<int> EditCommand { get; }
}
