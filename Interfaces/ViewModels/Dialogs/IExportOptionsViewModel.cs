using System.Collections.Generic;
using CardGenerator.Entities;

namespace CardGenerator.Interfaces.ViewModels.Dialogs;

/// <summary>
/// The export options view model interface.
/// </summary>
public interface IExportOptionsViewModel
{
    /// <summary>
    /// Gets the font options.
    /// </summary>
    Font Font { get; }

    /// <summary>
    /// Gets the fonts available on the system.
    /// </summary>
    IEnumerable<string> AvailableFonts { get; }
}
