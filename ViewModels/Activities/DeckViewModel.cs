using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using DrinkingBuddy.Domain;
using DrinkingBuddy.Entities;
using DrinkingBuddy.Helpers;
using DrinkingBuddy.Input;
using DrinkingBuddy.Interfaces.ViewModels.Activities;
using DrinkingBuddy.ViewModels.Dialogs;
using DrinkingBuddy.Views;
using Microsoft.Win32;
using DialogHost = MaterialDesignThemes.Wpf.DialogHost;

namespace DrinkingBuddy.ViewModels.Activities;

/// <summary>
///     The deck view model.
/// </summary>
public sealed class DeckViewModel(Deck entity, CardRepository cardRepository) : ViewModelBase, IDeckViewModel
{
    public string Name
    {
        get => entity.Name;
        set
        {
            if (entity.Name != value)
            {
                entity.Name = value;
                OnPropertyChanged();
            }
        }
    }

    public string Description
    {
        get => entity.Description;
        set
        {
            if (entity.Description != value)
            {
                entity.Description = value;
                OnPropertyChanged();
            }
        }
    }

    public string FilePath
    {
        get => entity.Image?.FilePath ?? string.Empty;
        set
        {
            if (entity.Image?.FilePath != value)
            {
                UpdateImageData(value);
                OnPropertyChanged();
            }
        }
    }

    public byte[]? ImageThumb => entity.Image?.ThumbBytes;

    public IAsyncRelayCommand AddCardCommand => new AsyncRelayCommand(AddCard);

    public IAsyncRelayCommand? SaveCommand { get; set; }

    public IRelayCommand? CancelCommand { get; set; }

    public IRelayCommand SelectFileCommand => new RelayCommand(SelectFile);

    public ObservableCollection<Card> Cards { get; } = new(cardRepository.GetCardsForDeck(entity.Id)!.Result);

    private void SelectFile()
    {
        var dialog = new OpenFileDialog() { Multiselect = false };

        if (dialog.ShowDialog() is true)
        {
            UpdateImageData(dialog.FileName);
        }
    }

    private void UpdateImageData(string filePath)
    {
        if (!File.Exists(filePath)) return;
        using var image = Image.FromFile(filePath);
        using var thumb = image.GetThumbnailImage(128, 128, null, 0);

        entity.Image = new ImageData
        {
            FilePath = filePath,
            Bytes = ImageHelpers.GetImageBytes(image),
            ThumbBytes = ImageHelpers.GetImageBytes(thumb)
        };

        OnPropertyChanged(nameof(FilePath));
        OnPropertyChanged(nameof(ImageThumb));
    }

    private async Task AddCard()
    {
        var viewModel = new AddCardViewModel()
        {
            AddCommand = new RelayCommand(() => DialogHost.Close("RootDialog", true)),
            CancelCommand = new RelayCommand(() => DialogHost.Close("RootDialog", false))
        };
        var content = new DialogControl()
        {
            DataContext = viewModel
        };

        var result = await DialogHost.Show(content, "RootDialog");
        if (result is true)
        {
            Cards.Add(new Card()
            {
                Description = viewModel.FlavourText,
                Image = viewModel.ImageData,
                DeckId = entity.Id,
                Deck = entity
            });

            OnPropertyChanged(nameof(Cards));
        }
    }
}
