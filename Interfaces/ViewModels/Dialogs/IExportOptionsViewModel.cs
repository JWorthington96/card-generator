using System.Collections.Generic;
using CardGenerator.Entities;

namespace CardGenerator.Interfaces.ViewModels.Dialogs;

public interface IExportOptionsViewModel
{
    Font Font { get; set; }
    IEnumerable<string> AvailableFonts { get; set; }
}
