using CardGenerator.Entities;

namespace CardGenerator.Interfaces.Services;

/// <summary>
/// Interface for the PDF export service.
/// </summary>
public interface IPdfExportService
{
    /// <summary>
    /// Exports the deck to a pdf.
    /// </summary>
    void Export(Deck deck, string filePath, Font font);
}
