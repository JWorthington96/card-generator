using CardGenerator.Entities;
using CardGenerator.Interfaces.ViewModels.Cards;

namespace CardGenerator.ViewModels.Cards;

public class CardViewModel : ViewModelBase, ICardViewModel
{
    public int Id { get; set; }
    public string FlavourText { get; set; } = string.Empty;
    public ImageData ImageData { get; set; } = new();
    public bool IsModified { get; set; }

    public object Clone() => new CardViewModel { Id = Id, FlavourText = FlavourText, ImageData = ImageData };

    public Card CreateCard() => new() { Id = Id, Description = FlavourText, Image = ImageData };

    public bool Equals(ICardViewModel? other)
    {
        if (other is null) return false;

        var textEqual = FlavourText.Equals(other.FlavourText);
        if (textEqual && ImageData is null && other.ImageData is null) return true;
        if (ImageData is null) return false;
        return textEqual && ImageData.Equals(other.ImageData);
    }
}
