using System.Collections.ObjectModel;
using CardGenerator.Entities;
using CardGenerator.Interfaces.Input;
using CardGenerator.Interfaces.ViewModels.Decks;

namespace CardGenerator.Interfaces.ViewModels;

/// <summary>
/// The export view model interface.
/// </summary>
public interface IExportViewModel
{
    /// <summary>
    /// Gets the current deck.
    /// </summary>
    IDeckViewModel? CurrentDeck { get; }

    /// <summary>
    /// Gets or sets the selected deck.
    /// </summary>
    public Deck? SelectedDeck { get; set; }

    /// <summary>
    /// Gets the decks.
    /// </summary>
    public ObservableCollection<Deck> Decks { get; }

    /// <summary>
    /// Gets the export command.
    /// </summary>
    IRelayCommand ExportCommand { get; }

    /// <summary>
    /// Gets the options command.
    /// </summary>
    IAsyncRelayCommand OptionsCommand { get; }
}
