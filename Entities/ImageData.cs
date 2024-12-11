using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace CardGenerator.Entities;

/// <summary>
/// The image data class
/// </summary>
/// <seealso cref="DbEntity"/>
/// <seealso cref="IEquatable{ImageData}"/>
public class ImageData : DbEntity, IEquatable<ImageData>
{
    /// <summary>
    /// Gets or sets the file path.
    /// </summary>
    [MaybeNull]
    public string FilePath { get; set; }

    /// <summary>
    /// Gets or sets the byte array of the image.
    /// </summary>
    [MaybeNull]
    public byte[] Bytes { get; set; }

    /// <summary>
    /// Gets or sets the byte array of the thumbnail.
    /// </summary>
    [MaybeNull]
    public byte[] ThumbBytes { get; set; }

    /// <summary>
    /// Gets or sets the id of the deck that uses the image.
    /// </summary>
    public int? DeckId { get; set; }

    /// <summary>
    /// Gets or sets the id of the card that uses the image.
    /// </summary>
    public int? CardId { get; set; }

    /// <inheritdoc />
    public override bool Equals(object? other) => other is ImageData && Equals(other as ImageData);

    /// <inheritdoc />
    public bool Equals(ImageData? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        if (Bytes is null && other.Bytes is null && FilePath is null && other.FilePath is null) return true;
        else if (Bytes is null || FilePath is null) return false;
        return FilePath.Equals(other.FilePath) && Bytes.SequenceEqual(other.Bytes);
    }

    /// <inheritdoc />
    public override int GetHashCode() => HashCode.Combine(FilePath, Bytes);
}
