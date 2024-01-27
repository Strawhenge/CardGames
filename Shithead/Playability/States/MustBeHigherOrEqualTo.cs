using CardGames.Core.Cards;
using CardGames.Core.Cards.Order;

namespace Shithead.Playability
{
    class MustBeHigherOrEqualTo : State
    {
        readonly Card _card;
        readonly CardOrder _order;

        public MustBeHigherOrEqualTo(Card card, CardOrder order)
        {
            _card = card;
            _order = order;
        }

        public override bool CanPlay(Card card)
        {
            return card.IsRankHigherThanOrSameAs(_card, _order);
        }
    }
}
