using WpfAppBase.Interfaces.Services;
using WpfAppBase.Interfaces.ViewModels;
using WpfAppBase.ViewModels.Activities;

namespace WpfAppBase.ViewModels;

/// <summary>
///     The main window view model.
/// </summary>
public sealed class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
{
    /// <summary>
    ///     Constructor for the main window view model.
    /// </summary>
    /// <param name="exampleService"> The example service.</param>
    public MainWindowViewModel(IExampleService exampleService)
    {
        ActivityViewModel = new DefaultActivityViewModel(exampleService);
    }

    ViewModelBase? activityViewModel;
    /// <inheritdoc/>
    public ViewModelBase? ActivityViewModel
    {
        get => activityViewModel;
        set
        {
            activityViewModel = value;
            OnPropertyChanged();
        }
    }
}

