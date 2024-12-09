using System.Collections.ObjectModel;
using CardGenerator.Entities;
using CardGenerator.Interfaces.Input;
using CardGenerator.Interfaces.ViewModels.Decks;

namespace CardGenerator.Interfaces.ViewModels;

public interface IExportViewModel
{
    IDeckViewModel? CurrentDeck { get; }

    public Deck? SelectedDeck { get; set; }

    public ObservableCollection<Deck> Decks { get; }

    IRelayCommand ExportCommand { get; }
}
