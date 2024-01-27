using CardGames.Core.Cards;
using System;

namespace Shithead.Selection
{
    public class GroupableCard
    {
        readonly Action<Card> _addToSelection;

        public GroupableCard(Card card, Action<Card> addToSelection)
        {
            Card = card;
            _addToSelection = addToSelection;
        }

        public Card Card { get; }

        public void AddToSelection() => _addToSelection(Card);
    }
}
