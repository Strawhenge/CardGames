using CardGames.Core.Cards;

namespace Shithead.Playability
{
    abstract class State
    {
        public static State EmptyWastepile { get; } = new EmptyWastepile();

        public static State MustBeHigherOrEqualTo(Rank rank) =>
            new MustBeHigherOrEqualTo(rank);

        public abstract bool CanPlay(Card card);
    }
}
