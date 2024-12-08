using DrinkingBuddy.Interfaces.Input;

namespace DrinkingBuddy.Interfaces.ViewModels.Activities;

/// <summary>
///     Interface for the card collection view model.
/// </summary>
public interface IDeckViewModel
{
    /// <summary>
    ///     An example command.
    /// </summary>
    IRelayCommand ExampleCommand { get; }

    /// <summary>
    ///     An example property.
    /// </summary>
    string ExampleProperty { get; }
}
