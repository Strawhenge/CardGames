using CardGames.Core.Cards;
using System.Collections.Generic;

namespace Shithead
{
    public class Wastepile
    {
        readonly Stack<Card> _cards = new Stack<Card>();

        public IReadOnlyList<Card> Cards => _cards.ToArray();

        public void Add(Card card) => _cards.Push(card);

        public IReadOnlyList<Card> Clear()
        {
            var cards = _cards.ToArray();
            _cards.Clear();
            return cards;
        }
    }
}
