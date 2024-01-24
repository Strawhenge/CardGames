namespace CardGames.Core.Cards
{
    public class CardNames : ICardLocalizer
    {
        public string GetName(Card card)
        {
            if (card.Rank == Rank.Joker)
                switch (card.Suit)
                {
                    case Suit.RedJoker:
                        return "Red Joker";
                    case Suit.BlackJoker:
                        return "Black Joker";
                }

            return $"{card.Rank} of {card.Suit}";
        }
    }
}
