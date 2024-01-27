using CardGames.Core.Cards;
using System.Collections.Generic;

namespace Shithead
{
    public static class WastepileExtensions
    {
        public static void Add(this Wastepile wastepile, params Card[] cards) =>
            wastepile.Add((IReadOnlyList<Card>)cards);

        public static void Add(this Wastepile wastepile, IReadOnlyList<Card> cards)
        {
            foreach (Card card in cards)
                wastepile.Add(card);
        }
    }
}
