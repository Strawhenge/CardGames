namespace CardGames.Core.Cards
{
    public partial class Card
    {
        internal Card(Rank rank, Suit suit)
        {
            Rank = rank;
            Suit = suit;
        }

        public Rank Rank { get; }

        public Suit Suit { get; }

        public bool IsSameRankAs(Card card) => card.Rank == Rank;

        public bool IsSameSuitAs(Card card) => card.Suit == Suit;
    }
}
