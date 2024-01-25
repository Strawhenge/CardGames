using CardGames.Core.Cards;

namespace Shithead.Playability
{
    class MustBeLowerOrEqualTo : State
    {
        readonly Rank _rank;

        public MustBeLowerOrEqualTo(Rank rank)
        {
            _rank = rank;
        }

        public override bool CanPlay(Card card) => card.Rank <= _rank;
    }
}
