using CardGenerator.ViewModels;
using MaterialDesignThemes.Wpf;

namespace CardGenerator.Interfaces.Entities;

/// <summary>
/// The destination interface.
/// </summary>
/// <typeparam name="T"/>
public interface IDestination<out T> where T : ViewModelBase
{
    /// <summary>
    /// Gets the destination information.
    /// </summary>
    DestinationInfo Info { get; }

    /// <summary>
    /// Gets the view model corresponding to the destination.
    /// </summary>
    T ViewModel { get; }
}

/// <summary>
/// The destination information struct.
/// </summary>
/// <param name="name">The name.</param>
/// <param name="selectedIcon">The selected icon.</param>
/// <param name="unselectedIcon">The unselected icon.</param>
public readonly struct DestinationInfo(string name, PackIconKind selectedIcon, PackIconKind unselectedIcon)
{
    /// <summary>
    /// Gets the name of the destination.
    /// </summary>
    public string Name { get; } = name;

    /// <summary>
    /// Gets the selected icon.
    /// </summary>
    public PackIconKind SelectedIcon { get; } = selectedIcon;

    /// <summary>
    /// Gets the unselected icon.
    /// </summary>
    public PackIconKind UnselectedIcon { get; } = unselectedIcon;

    /// <inheritdoc />
    public override string ToString() => Name;
}
