using System;
using System.Collections.Generic;
using System.Text;

namespace CardGames.Core.Cards.Order
{
    public abstract class CardOrder : IComparer<Card>
    {
        public static CardOrder AceIsHigh { get; } = new AceIsHigh();

        public static CardOrder AceIsLow { get; } = new AceIsLow();

        public abstract int Compare(Card x, Card y);
    }

    public class AceIsHigh : CardOrder
    {
        public override int Compare(Card x, Card y)
        {
            return x.Rank.CompareTo(y.Rank);
        }
    }

    public class AceIsLow : CardOrder
    {
        public override int Compare(Card x, Card y)
        {
            if (x.Rank == Rank.Ace)
                return y.Rank == Rank.Ace ? 0 : -1;

            if (y.Rank == Rank.Ace)
                return 1;

            return x.Rank.CompareTo(y.Rank);
        }
    }
}
