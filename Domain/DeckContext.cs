using DrinkingBuddy.Entities;
using Microsoft.EntityFrameworkCore;

namespace DrinkingBuddy.Domain
{
    public class DeckContext : DbContext
    {
        public DbSet<Deck> Decks { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<ImageData> Images { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Decks.db");
            optionsBuilder.UseLazyLoadingProxies(true);
        }
    }
}
