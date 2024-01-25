using CardGames.Core.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shithead
{
    public class CardPlayability
    {
        readonly Wastepile _wastepile;

        public CardPlayability(Wastepile wastepile)
        {
            _wastepile = wastepile;
        }

        public bool CanPlay(Card card)
        {
            if (!_wastepile.Cards.Any())
                return true;

            return card.Rank >= _wastepile.Cards[0].Rank;
        }
    }
}
