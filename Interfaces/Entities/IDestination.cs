using CardGenerator.ViewModels;
using MaterialDesignThemes.Wpf;

namespace CardGenerator.Interfaces.Entities;

public interface IDestination<out T> where T : ViewModelBase
{
    DestinationInfo Info { get; }

    T ViewModel { get; }
}

public readonly struct DestinationInfo(string name, PackIconKind selectedIcon, PackIconKind unselectedIcon)
{
    public string Name { get; } = name;

    public PackIconKind SelectedIcon { get; } = selectedIcon;

    public PackIconKind UnselectedIcon { get; } = unselectedIcon;

    public override string ToString() => Name;
}
