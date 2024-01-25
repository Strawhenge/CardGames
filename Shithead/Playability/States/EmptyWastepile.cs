using CardGames.Core.Cards;

namespace Shithead.Playability
{
    class EmptyWastepile : State
    {
        public override bool CanPlay(Card card) => true;
    }
}
