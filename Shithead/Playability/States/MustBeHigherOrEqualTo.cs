using CardGames.Core.Cards;

namespace Shithead.Playability
{
    class MustBeHigherOrEqualTo : State
    {
        readonly Rank _rank;

        public MustBeHigherOrEqualTo(Rank rank)
        {
            _rank = rank;
        }

        public override bool CanPlay(Card card) => card.Rank >= _rank;
    }
}
