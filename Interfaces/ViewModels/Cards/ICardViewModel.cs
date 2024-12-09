using System;
using System.ComponentModel;
using CardGenerator.Entities;

namespace CardGenerator.Interfaces.ViewModels.Cards;

public interface ICardViewModel : IEquatable<ICardViewModel>, IEntityViewModel, ICloneable, INotifyPropertyChanged
{
    int Id { get; set; }
    string FlavourText { get; set; }
    ImageData ImageData { get; set; }

    Card CreateCard();
}
