namespace DrinkingBuddy.Entities;

public class ImageData : DbEntry
{
    public string FilePath { get; set; }
    public byte[] Bytes { get; set; }
    public byte[] ThumbBytes { get; set; }

    public int? DeckId { get; set; }
    public int? CardId { get; set; }
}
