using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrinkingBuddy.Entities;

namespace DrinkingBuddy.Domain
{
    public class CardRepository(DeckContext deckContext) : Repository<Card>(deckContext), IRepository<Card>
    {
        public async Task<List<Card>> GetCardsForDeck(int deckId)
        {
            var allCards = await base.GetAllAsync();
            return allCards.Where(card => card.DeckId == deckId).ToList();
        }
    }
}
