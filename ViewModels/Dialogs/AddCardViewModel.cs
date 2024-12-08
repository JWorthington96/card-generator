using System.Drawing;
using System.IO;
using DrinkingBuddy.Entities;
using DrinkingBuddy.Helpers;
using DrinkingBuddy.Input;
using DrinkingBuddy.Interfaces.ViewModels.Dialogs;
using Microsoft.Win32;

namespace DrinkingBuddy.ViewModels.Dialogs;

class AddCardViewModel : ViewModelBase, IAddCardViewModel
{
    public string FlavourText { get; set; } = string.Empty;
    public ImageData ImageData { get; set; } = new ImageData();

    public IRelayCommand SelectFileCommand => new RelayCommand(SelectFile);

    public IRelayCommand? AddCommand { get; set; }
    public IRelayCommand? CancelCommand { get; set; }

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

        ImageData = new ImageData
        {
            FilePath = filePath,
            Bytes = ImageHelpers.GetImageBytes(image),
            ThumbBytes = ImageHelpers.GetImageBytes(thumb)
        };

        OnPropertyChanged(nameof(ImageData));
    }
}
