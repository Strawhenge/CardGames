namespace CardGames.Core.Cards.Order
{
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
