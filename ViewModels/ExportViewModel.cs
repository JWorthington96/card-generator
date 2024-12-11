using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CardGenerator.Domain;
using CardGenerator.Entities;
using CardGenerator.Input;
using CardGenerator.Interfaces.Factories;
using CardGenerator.Interfaces.Input;
using CardGenerator.Interfaces.Services;
using CardGenerator.Interfaces.ViewModels;
using CardGenerator.Interfaces.ViewModels.Decks;
using CardGenerator.ViewModels.Decks;
using CardGenerator.ViewModels.Dialogs;
using CardGenerator.Views;
using MaterialDesignThemes.Wpf;
using Microsoft.Win32;

namespace CardGenerator.ViewModels;

/// <summary>
/// The export view model.
/// </summary>
/// <param name="genericFactory">The generic factory.</param>
/// <param name="deckRepository">The deck repository.</param>
/// <param name="pdfExportService">The pdf export service.</param>
public class ExportViewModel(IGenericFactory genericFactory, IRepository<Deck> deckRepository, IPdfExportService pdfExportService) : ViewModelBase, IExportViewModel
{
    private Font exportFont = new();

    /// <inheritdoc/>
    public IDeckViewModel? CurrentDeck => SelectedDeck is null ? null : genericFactory.Create<DeckViewModel>(SelectedDeck);

    private Deck? selectedDeck;
    /// <inheritdoc/>
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

    /// <inheritdoc/>
    public ObservableCollection<Deck> Decks => new(deckRepository.GetAllAsync().Result!);

    /// <inheritdoc/>
    public IRelayCommand ExportCommand => new RelayCommand(Export);

    /// <inheritdoc/>
    public IAsyncRelayCommand OptionsCommand => new AsyncRelayCommand(OpenOptions);

    private void Export()
    {
        if (SelectedDeck is null) return;

        var dialog = new OpenFolderDialog();

        if (dialog.ShowDialog() is true)
        {
            pdfExportService.Export(SelectedDeck, dialog.FolderName, exportFont);
        }
    }

    private async Task OpenOptions()
    {
        var viewModel = genericFactory.Create<ExportOptionsViewModel>(exportFont);

        var content = new DialogControl { DataContext = viewModel };

        var result = await DialogHost.Show(content, "RootDialog") as Font;
        if (result is not null)
        {
            exportFont = result;
        }
    }
}
