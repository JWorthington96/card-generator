using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using CardGenerator.Entities;
using CardGenerator.Interfaces.ViewModels.Dialogs;

namespace CardGenerator.ViewModels.Dialogs;

/// <summary>
/// The export options view model.
/// </summary>
public class ExportOptionsViewModel(Font font) : DialogViewModel<Font>(font), IExportOptionsViewModel
{
    /// <inheritdoc />
    public IEnumerable<string> AvailableFonts { get; } = Fonts.SystemFontFamilies.SelectMany(f => f.FamilyNames.Values);

    /// <inheritdoc />
    public Font Font { get; } = font;
}
