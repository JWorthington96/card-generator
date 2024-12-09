using System.Collections.ObjectModel;
using CardGenerator.Domain;
using CardGenerator.Entities;
using CardGenerator.Input;
using CardGenerator.Interfaces.Factories;
using CardGenerator.Interfaces.Input;
using CardGenerator.Interfaces.Services;
using CardGenerator.Interfaces.ViewModels;
using CardGenerator.Interfaces.ViewModels.Decks;
using CardGenerator.ViewModels.Decks;
using Microsoft.Win32;

namespace CardGenerator.ViewModels;

public class ExportViewModel(IGenericFactory genericFactory, IRepository<Deck> deckRepository, IPdfExportService pdfExportService) : ViewModelBase, IExportViewModel
{
    public IDeckViewModel? CurrentDeck => SelectedDeck is null ? null : genericFactory.Create<DeckViewModel>(SelectedDeck);

    private Deck? selectedDeck;
    public Deck? SelectedDeck
    {
        get => selectedDeck;
        set
        {
            selectedDeck = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(CurrentDeck));
        }
    }

    public ObservableCollection<Deck> Decks => new(deckRepository.GetAllAsync().Result!);

    public IRelayCommand ExportCommand => new RelayCommand(Export);

    private void Export()
    {
        if (SelectedDeck is null) return;

        var dialog = new OpenFolderDialog();

        if (dialog.ShowDialog() is true)
        {
            pdfExportService.Export(SelectedDeck, dialog.FolderName);
        }
    }


    //public IRelayCommand AddCommand => new RelayCommand(() => CreateDeckViewModel(new Deck()));

    //public IAsyncRelayCommand<int> EditCommand => new AsyncRelayCommand<int>(EditDeckAsync);

    //public IAsyncRelayCommand<int> DeleteCommand => new AsyncRelayCommand<int>(DeleteDeckAsync);

    //private async Task EditDeckAsync(int id)
    //{
    //    var deck = await deckRepository.GetByIdAsync(id);
    //    CreateDeckViewModel(deck);
    //}

    //private async Task DeleteDeckAsync(int id) => await deckRepository.DeleteByIdAsync(id);

    //private void CreateDeckViewModel(Deck deck)
    //{
    //    CurrentDeck = genericFactory.Create<DeckViewModel>(deck);
    //    CurrentDeck.SaveCommand = new AsyncRelayCommand(() => SaveDeck(deck));
    //    CurrentDeck.CancelCommand = new RelayCommand(Cancel);

    //    OnPropertyChanged(nameof(CurrentDeck));
    //}

    //private async Task SaveDeck(Deck deck)
    //{
    //    foreach (var card in CurrentDeck!.Cards)
    //    {
    //        var existing = deck.Cards.FirstOrDefault(c => c.Id == card.Id);
    //        var newCard = new Card() { Description = card.FlavourText, Image = card.ImageData, DeckId = deck.Id, Deck = deck };
    //        if (existing is not null)
    //        {
    //            deck.Cards.Remove(existing);
    //            newCard.Id = card.Id;
    //        }
    //        deck.Cards.Add(newCard);
    //    }
    //    await deckRepository.AddOrUpdateAsync(deck);
    //    CurrentDeck = null;
    //    OnPropertyChanged(nameof(Decks));
    //    OnPropertyChanged(nameof(CurrentDeck));
    //}

    //private void Cancel()
    //{
    //    CurrentDeck?.SaveCommand?.Cancel();
    //    CurrentDeck = null;
    //    OnPropertyChanged(nameof(CurrentDeck));
    //}
}
