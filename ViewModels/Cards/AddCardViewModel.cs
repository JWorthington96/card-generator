using System.Drawing;
using System.IO;
using CardGenerator.Entities;
using CardGenerator.Helpers;
using CardGenerator.Input;
using CardGenerator.Interfaces.Input;
using CardGenerator.Interfaces.ViewModels.Cards;
using MaterialDesignThemes.Wpf;
using Microsoft.Win32;

namespace CardGenerator.ViewModels.Cards;

public class AddCardViewModel(ICardViewModel card) : ViewModelBase, IAddCardViewModel<ICardViewModel>
{
    public ICardViewModel Card { get; } = card;

    public string ConfirmLabel { get; set; } = "Confirm";

    public IRelayCommand SelectFileCommand => new RelayCommand(SelectFile);

    public IRelayCommand ConfirmCommand => new RelayCommand(() => DialogHost.Close("RootDialog", Card));
    public IRelayCommand CancelCommand => new RelayCommand(() => DialogHost.Close("RootDialog", null));

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
