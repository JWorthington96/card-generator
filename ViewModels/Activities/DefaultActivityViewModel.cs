using System;
using WpfAppBase.Input;
using WpfAppBase.Interfaces.Input;
using WpfAppBase.Interfaces.Services;
using WpfAppBase.Interfaces.ViewModels.Activities;

namespace WpfAppBase.ViewModels.Activities;

/// <summary>
///     The default activity view model.
/// </summary>
public sealed class DefaultActivityViewModel : ViewModelBase, IDefaultActivityViewModel
{
    /// <summary>
    ///     Constructor for the default activity view model.
    /// </summary>
    /// <param name="exampleService"></param>
    public DefaultActivityViewModel(IExampleService exampleService)
    {
        ArgumentNullException.ThrowIfNull(exampleService);
        ExampleCommand = new RelayCommand(exampleService.ExampleMethod);
    }

    /// <inheritdoc/>
    public IRelayCommand ExampleCommand { get; init; }

    /// <inheritdoc/>
    public string ExampleProperty => "Example";
}
