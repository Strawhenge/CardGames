namespace CardGames.Core.Cards
{
    public class Card
    {
        internal Card(Rank rank, Suit suit)
        {
            Rank = rank;
            Suit = suit;
        }

        public Rank Rank { get; }

        public Suit Suit { get; }
    }
}
