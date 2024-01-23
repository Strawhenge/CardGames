using CardGames.Core.Cards;
using System.Collections.Generic;
using System.Linq;

namespace CardGames.Core.Deck
{
    public class Deck
    {
        public Deck(IEnumerable<Card> cards)
        {
            Cards = cards.ToArray();
        }

        public IReadOnlyList<Card> Cards { get; }
    }
}
