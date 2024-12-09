using System;
using System.Linq;

namespace CardGenerator.Entities;

public class ImageData : DbEntry, IEquatable<ImageData>
{
    public string FilePath { get; set; }
    public byte[] Bytes { get; set; }
    public byte[] ThumbBytes { get; set; }

    public int? DeckId { get; set; }
    public int? CardId { get; set; }

    public bool Equals(ImageData? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return FilePath.Equals(other.FilePath) && Bytes.SequenceEqual(other.Bytes);
    }
}
