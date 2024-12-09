using CardGenerator.Interfaces.Entities;
using CardGenerator.Interfaces.Factories;
using CardGenerator.ViewModels;
using MaterialDesignThemes.Wpf;

namespace CardGenerator.Entities
{
    public class ExportDestination(IGenericFactory genericFactory) : IDestination<ExportViewModel>
    {
        public DestinationInfo Info { get; } = new("Export", PackIconKind.ExportVariant, PackIconKind.ExportVariant);

        public ExportViewModel ViewModel { get; } = genericFactory.Create<ExportViewModel>();

        public override string ToString() => Info.Name;
    }
}
