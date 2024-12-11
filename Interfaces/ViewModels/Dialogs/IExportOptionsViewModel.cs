using System.Collections.Generic;
using CardGenerator.Entities;

namespace CardGenerator.Interfaces.ViewModels.Dialogs;

/// <summary>
/// The export options view model interface.
/// </summary>
public interface IExportOptionsViewModel : IDialogViewModel<Font>
{
    /// <summary>
    /// Gets the fonts available on the system.
    /// </summary>
    IEnumerable<string> AvailableFonts { get; }
}
