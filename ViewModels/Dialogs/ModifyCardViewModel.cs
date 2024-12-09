using System.Drawing;
using System.IO;
using CardGenerator.Entities;
using CardGenerator.Helpers;
using CardGenerator.Input;
using CardGenerator.Interfaces.Input;
using CardGenerator.Interfaces.ViewModels.Cards;
using CardGenerator.Interfaces.ViewModels.Dialogs;
using Microsoft.Win32;

namespace CardGenerator.ViewModels.Dialogs;

public class ModifyCardViewModel : ViewModelBase, IModifyCardViewModel
{
    public ICardViewModel Card { get; set; }
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

        if (Card is not null)
        {
            Card.ImageData = new ImageData
            {
                FilePath = filePath,
                Bytes = ImageHelpers.GetImageBytes(image),
                ThumbBytes = ImageHelpers.GetImageBytes(thumb)
            };
            OnPropertyChanged(nameof(Card));
        }
    }
}
