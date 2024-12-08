using System.Drawing;
using System.IO;
using DrinkingBuddy.Entities;
using DrinkingBuddy.Helpers;
using DrinkingBuddy.Input;
using DrinkingBuddy.Interfaces.ViewModels.Activities;
using Microsoft.Win32;

namespace DrinkingBuddy.ViewModels.Activities;

/// <summary>
///     The deck view model.
/// </summary>
public sealed class DeckViewModel(Deck entity) : ViewModelBase, IDeckViewModel
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

    public IAsyncRelayCommand? SaveCommand { get; set; }

    public IRelayCommand? CancelCommand { get; set; }

    public IRelayCommand SelectFileCommand => new RelayCommand(SelectFile);

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
}
