using CardGames.Core.Cards.Order;

namespace CardGames.Core.Cards
{
    public static class CardExtensions
    {
        public static bool IsRankHigherThan(this Card card, Card other, CardOrder order) =>
            order.Compare(card, other) > 0;

        public static bool IsRankHigherThanOrSameAs(this Card card, Card other, CardOrder order) =>
            order.Compare(card, other) >= 0;

        public static bool IsRankLowerThan(this Card card, Card other, CardOrder order) =>
            order.Compare(card, other) < 0;

        public static bool IsRankLowerThanOrSameAs(this Card card, Card other, CardOrder order) =>
            order.Compare(card, other) <= 0;
    }
}
