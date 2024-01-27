namespace CardGames.Core.Cards.Order
{
    public class AceIsHigh : CardOrder
    {
        public override int Compare(Card x, Card y)
        {
            return x.Rank.CompareTo(y.Rank);
        }
    }
}
