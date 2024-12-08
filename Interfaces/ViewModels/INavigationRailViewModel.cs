using DrinkingBuddy.Interfaces.Entities;
using DrinkingBuddy.ViewModels;
using System.Collections.ObjectModel;

namespace DrinkingBuddy.Interfaces.ViewModels;

public interface INavigationRailViewModel
{
    ObservableCollection<IDestination<ViewModelBase>> Destinations { get; }
}
