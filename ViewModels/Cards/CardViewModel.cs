using CardGenerator.Entities;
using CardGenerator.Interfaces.ViewModels.Cards;

namespace CardGenerator.ViewModels.Cards;

/// <summary>
/// The card view model.
/// </summary>
public class CardViewModel : ViewModelBase, ICardViewModel
{
    /// <inheritdoc />
    public int Id { get; set; }

    private string title = string.Empty;
    /// <inheritdoc />
    public string Title
    {
        get => title;
        set
        {
            title = value;
            OnPropertyChanged();
        }
    }

    private string flavourText = string.Empty;
    /// <inheritdoc />
    public string FlavourText
    {
        get => flavourText;
        set
        {
            flavourText = value;
            OnPropertyChanged();
        }
    }

    private ImageData image = new();
    /// <inheritdoc />
    public ImageData Image
    {
        get => image;
        set
        {
            image = value;
            OnPropertyChanged();
        }
    }

    /// <inheritdoc />
    public bool IsModified { get; set; }

    /// <inheritdoc />
    public object Clone() => new CardViewModel { Id = Id, Title = title, FlavourText = FlavourText, Image = Image };

    /// <inheritdoc />
    public Card CreateCard() => new() { Id = Id, Title = title, FlavourText = FlavourText, Image = Image };

    /// <inheritdoc />
    public bool Equals(ICardViewModel? other)
    {
        if (other is null) return false;

        var textEqual = Title.Equals(other.Title) && FlavourText.Equals(other.FlavourText);
        if (textEqual && Image is null && other.Image is null) return true;
        if (Image is null) return false;
        return textEqual && Image.Equals(other.Image);
    }

    public static ICardViewModel CreateFromCard(Card card) => new CardViewModel() { Id = card.Id, Title = card.Title, FlavourText = card.FlavourText, Image = card.Image };
}
