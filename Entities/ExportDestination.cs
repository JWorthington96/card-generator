using CardGenerator.Interfaces.Entities;
using CardGenerator.Interfaces.Factories;
using CardGenerator.ViewModels;
using MaterialDesignThemes.Wpf;

namespace CardGenerator.Entities;

/// <summary>
/// The export destination.
/// </summary>
/// <seealso cref="IDestination{ExportViewModel}"/>
public class ExportDestination(IGenericFactory genericFactory) : IDestination<ExportViewModel>
{
    /// <inheritdoc />
    public DestinationInfo Info { get; } = new("Export", PackIconKind.ExportVariant, PackIconKind.ExportVariant);

    /// <inheritdoc />
    public ExportViewModel ViewModel { get; } = genericFactory.Create<ExportViewModel>();

    /// <inheritdoc />
    public override string ToString() => Info.Name;
}
