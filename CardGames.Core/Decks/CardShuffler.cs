using CardGames.Core.Cards;
using CardGames.Core.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace CardGames.Core.Decks
{
    public class CardShuffler : ICardShuffler
    {
        readonly IRandomIntGenerator _random;

        public CardShuffler(IRandomIntGenerator random)
        {
            _random = random;
        }

        public IReadOnlyList<Card> Shuffle(IReadOnlyList<Card> cards)
        {
            var remainingCards = cards.ToList();
            var newCards = new List<Card>();

            while (remainingCards.Any())
            {
                var card = remainingCards.ElementAt(_random.Generate(0, remainingCards.Count));
                remainingCards.Remove(card);
                newCards.Add(card);
            }

            return newCards.AsReadOnly();
        }
    }
}
