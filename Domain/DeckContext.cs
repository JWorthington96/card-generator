using CardGenerator.Entities;
using Microsoft.EntityFrameworkCore;

namespace CardGenerator.Domain;

/// <summary>
/// The DB context for the application, defining the DBSets for Decks, Cards and Images.
/// </summary>
public class DeckContext : DbContext
{

    /// <summary>
    /// Gets or sets the decks db set.
    /// </summary>
    public DbSet<Deck> Decks { get; set; }


    /// <summary>
    /// Gets or sets the cards db set.
    /// </summary>
    public DbSet<Card> Cards { get; set; }


    /// <summary>
    /// Gets or sets the images db set.
    /// </summary>
    public DbSet<ImageData> Images { get; set; }

    /// <inheritdoc />
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Decks.db");
        optionsBuilder.UseLazyLoadingProxies(true);
    }
}
