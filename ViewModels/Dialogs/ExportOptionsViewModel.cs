using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using CardGenerator.Entities;
using CardGenerator.Interfaces.ViewModels.Dialogs;

namespace CardGenerator.ViewModels.Dialogs;

public class ExportOptionsViewModel : ViewModelBase, IExportOptionsViewModel
{
    public IEnumerable<string> AvailableFonts { get; set; } = Fonts.SystemFontFamilies.SelectMany(f => f.FamilyNames.Values);

    public Font Font { get; set; } = new Font();
}
