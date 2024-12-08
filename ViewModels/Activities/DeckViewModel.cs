using System;
using DrinkingBuddy.Input;
using DrinkingBuddy.Interfaces.Input;
using DrinkingBuddy.Interfaces.Services;
using DrinkingBuddy.Interfaces.ViewModels.Activities;

namespace DrinkingBuddy.ViewModels.Activities;

/// <summary>
///     The card collection view model.
/// </summary>
public sealed class DeckViewModel : ViewModelBase, IDeckViewModel
{
    /// <summary>
    ///     Constructor for the default activity view model.
    /// </summary>
    /// <param name="exampleService"></param>
    public DeckViewModel(IExampleService exampleService)
    {
        ArgumentNullException.ThrowIfNull(exampleService);
        ExampleCommand = new RelayCommand(exampleService.ExampleMethod);
    }

    /// <inheritdoc/>
    public IRelayCommand ExampleCommand { get; init; }

    /// <inheritdoc/>
    public string ExampleProperty => "Example";
}
