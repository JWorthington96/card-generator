using System;
using System.ComponentModel;
using CardGenerator.Entities;

namespace CardGenerator.Interfaces.ViewModels.Cards;

/// <summary>
/// The card view model interface.
/// </summary>
public interface ICardViewModel : IEquatable<ICardViewModel>, IEntityViewModel, ICloneable, INotifyPropertyChanged
{
    /// <summary>
    /// Gets or sets the id.
    /// </summary>
    int Id { get; set; }

    /// <summary>
    /// Gets or sets the flavour text.
    /// </summary>
    string FlavourText { get; set; }

    /// <summary>
    /// Gets or sets the image.
    /// </summary>
    ImageData Image { get; set; }

    /// <summary>
    /// Gets or sets the id.
    /// </summary>
    Card CreateCard();
}
