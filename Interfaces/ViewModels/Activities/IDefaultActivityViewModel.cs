using WpfAppBase.Interfaces.Input;

namespace WpfAppBase.Interfaces.ViewModels.Activities;

/// <summary>
///     An example activity view model.
/// </summary>
public interface IDefaultActivityViewModel
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
