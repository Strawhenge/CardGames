using CardGames.Core.Cards;
using System.Collections.Generic;
using System.Linq;

namespace Shithead.Selection
{
    public class CardSelection
    {
        readonly List<Card> _cards;

        public CardSelection(Card card, IReadOnlyList<Card> _canBeGroupedWith)
        {
            _cards = new List<Card> { card };

            CanBeGroupedWith = _canBeGroupedWith
                .Select(x => new GroupableCard(x, AddToSelection))
                .ToArray();
        }

        public IReadOnlyList<Card> Cards => _cards.AsReadOnly();

        public IReadOnlyList<GroupableCard> CanBeGroupedWith { get; }

        void AddToSelection(Card card)
        {
            if (_cards.Contains(card))
                return;

            _cards.Add(card);
        }
    }
}
