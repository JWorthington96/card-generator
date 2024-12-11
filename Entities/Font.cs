namespace CardGenerator.Entities;


/// <summary>
/// The font. Contains all information needed for PdfSharp to generate a PDF document.
/// </summary>
/// <param name="family">The family.</param>
/// <param name="size">The size.</param>
/// <param name="isBold">If true, is bold.</param>
/// <param name="isItalic">If true, is italic.</param>
/// <param name="isUnderline">If true, is underline.</param>
/// <param name="isStrikethrough">If true, is strikethrough.</param>
public class Font(
    string family = "",
    double size = 12,
    bool isBold = false,
    bool isItalic = false,
    bool isUnderline = false,
    bool isStrikethrough = false)
{
    /// <summary>
    /// Gets or sets the font family.
    /// </summary>
    public string Family { get; set; } = family;

    /// <summary>
    /// Gets or sets the font size.
    /// </summary>
    public double Size { get; set; } = size;

    /// <summary>
    /// Gets or sets a value indicating whether the font should format as bold.
    /// </summary>
    public bool IsBold { get; set; } = isBold;

    /// <summary>
    /// Gets or sets a value indicating whether the font should format as italic.
    /// </summary>
    public bool IsItalic { get; set; } = isItalic;

    /// <summary>
    /// Gets or sets a value indicating whether the font should format as underline.
    /// </summary>
    public bool IsUnderline { get; set; } = isUnderline;

    /// <summary>
    /// Gets or sets a value indicating whether the font should format as strikethrough.
    /// </summary>
    public bool IsStrikethrough { get; set; } = isStrikethrough;
}
