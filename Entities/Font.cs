namespace CardGenerator.Entities;

public class Font(
    string family = "",
    double size = 12,
    bool isBold = false,
    bool isItalic = false,
    bool isUnderline = false,
    bool isStrikethrough = false)
{
    public string Family { get; set; } = family;
    public double Size { get; set; } = size;
    public bool IsBold { get; set; } = isBold;
    public bool IsItalic { get; set; } = isItalic;
    public bool IsUnderline { get; set; } = isUnderline;
    public bool IsStrikethrough { get; set; } = isStrikethrough;
}
