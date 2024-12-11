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

/// <summary>
/// The modify card view model.
/// </summary>
public class ModifyCardViewModel : ViewModelBase, IModifyCardViewModel
{
    /// <inheritdoc />
    public ICardViewModel Card { get; set; }

    /// <inheritdoc />
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
            Card.Image = new ImageData
            {
                FilePath = filePath,
                Bytes = ImageHelpers.GetImageBytes(image),
                ThumbBytes = ImageHelpers.GetImageBytes(thumb)
            };
        }
    }
}
