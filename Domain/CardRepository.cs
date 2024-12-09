using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardGenerator.Entities;

namespace CardGenerator.Domain
{
    public class CardRepository(DeckContext deckContext) : Repository<Card>(deckContext), IRepository<Card>
    {
        public async Task<List<Card>> GetCardsForDeck(int deckId, bool tracked = true)
        {
            var allCards = await GetAllAsync(tracked);
            return allCards.Where(card => card.DeckId == deckId).ToList();
        }
    }
}
