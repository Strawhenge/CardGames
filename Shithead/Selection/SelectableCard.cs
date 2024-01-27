using CardGames.Core.Cards;
using System;
using System.Collections.Generic;

namespace Shithead.Selection
{
    public class SelectableCard
    {
        readonly Card _card;
        readonly IReadOnlyList<Card> _canBeGroupedWith;

        public SelectableCard(Card card, IReadOnlyList<Card>? canBeGroupedWith = null)
        {
            _card = card;
            _canBeGroupedWith = canBeGroupedWith ?? Array.Empty<Card>();
        }

        public CardSelection CreateSelection()
        {
            return new CardSelection(_card, _canBeGroupedWith);
        }
    }
}
