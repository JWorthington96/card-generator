using CardGenerator.Entities;

namespace CardGenerator.Interfaces.Services;

/// <summary>
/// Interface for the image export service.
/// </summary>
public interface IImageExportService
{
    /// <summary>
    /// Exports the deck to a folder of images.
    /// </summary>
    void Export(Deck deck, string basePath, Font font);
}
