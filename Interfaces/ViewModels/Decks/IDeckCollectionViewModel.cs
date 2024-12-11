using System.Collections.ObjectModel;
using CardGenerator.Entities;
using CardGenerator.Interfaces.Input;

namespace CardGenerator.Interfaces.ViewModels.Decks;

public interface IDeckCollectionViewModel
{
    IModifyDeckViewModel? CurrentDeck { get; }

    public ObservableCollection<Deck> Decks { get; }

    IRelayCommand AddCommand { get; }
    IAsyncRelayCommand<int> EditCommand { get; }
}
