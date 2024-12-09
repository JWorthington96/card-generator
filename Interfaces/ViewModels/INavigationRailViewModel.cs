using System.Collections.ObjectModel;
using CardGenerator.Interfaces.Entities;
using CardGenerator.ViewModels;

namespace CardGenerator.Interfaces.ViewModels;

public interface INavigationRailViewModel
{
    ObservableCollection<IDestination<ViewModelBase>> Destinations { get; }
}
