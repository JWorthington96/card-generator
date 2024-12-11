﻿using CardGenerator.Entities;
using CardGenerator.Interfaces.ViewModels.Cards;

namespace CardGenerator.ViewModels.Cards;

/// <summary>
/// The card view model.
/// </summary>
public class CardViewModel : ViewModelBase, ICardViewModel
{
    /// <inheritdoc />
    public int Id { get; set; }

    /// <inheritdoc />
    public string FlavourText { get; set; } = string.Empty;

    /// <inheritdoc />
    public ImageData Image { get; set; } = new();

    /// <inheritdoc />
    public bool IsModified { get; set; }

    /// <inheritdoc />
    public object Clone() => new CardViewModel { Id = Id, FlavourText = FlavourText, Image = Image };

    /// <inheritdoc />
    public Card CreateCard() => new() { Id = Id, FlavourText = FlavourText, Image = Image };

    /// <inheritdoc />
    public bool Equals(ICardViewModel? other)
    {
        if (other is null) return false;

        var textEqual = FlavourText.Equals(other.FlavourText);
        if (textEqual && Image is null && other.Image is null) return true;
        if (Image is null) return false;
        return textEqual && Image.Equals(other.Image);
    }
}
