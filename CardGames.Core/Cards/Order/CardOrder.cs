using System.Collections.Generic;

namespace CardGames.Core.Cards.Order
{
    public abstract class CardOrder : IComparer<Card>
    {
        public static CardOrder AceIsHigh { get; } = new AceIsHigh();

        public static CardOrder AceIsLow { get; } = new AceIsLow();

        public abstract int Compare(Card x, Card y);
    }
}
