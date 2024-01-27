using CardGames.Core.Cards;
using CardGames.Core.Cards.Order;

namespace Shithead.Playability
{
    abstract class State
    {
        public static State EmptyWastepile { get; } = new EmptyWastepile();

        public static State MustBeHigherOrEqualTo(Card card, CardOrder order) =>
            new MustBeHigherOrEqualTo(card, order);

        public static State MustBeLowerOrEqualTo(Card card, CardOrder order) =>
            new MustBeLowerOrEqualTo(card, order);

        public abstract bool CanPlay(Card card);
    }
}
