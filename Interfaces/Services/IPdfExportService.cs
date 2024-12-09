using CardGenerator.Entities;

namespace CardGenerator.Interfaces.Services;

/// <summary>
///     Interface for the PDF export service.
/// </summary>
public interface IPdfExportService
{
    /// <summary>
    ///     Exports the card to a pdf.
    /// </summary>
    void Export(Deck cards, string filePath);
}
