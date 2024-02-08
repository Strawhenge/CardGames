using CardGames.Core.Cards;

namespace Shithead.CardCollections
{
    public class ThreeCards
    {
        public ThreeCards(Card first, Card second, Card third)
        {
            First = first;
            Second = second;
            Third = third;
        }

        public Card First { get; }
        
        public Card Second { get; }

        public Card Third { get; }
    }
}
