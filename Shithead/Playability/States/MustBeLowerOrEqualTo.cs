using CardGames.Core.Cards;
using CardGames.Core.Cards.Order;

namespace Shithead.Playability
{
    class MustBeLowerOrEqualTo : State
    {
        readonly Card _card;
        readonly CardOrder _order;

        public MustBeLowerOrEqualTo(Card card, CardOrder order)
        {
            _card = card;
            _order = order;
        }

        public override bool CanPlay(Card card)
        {
            return card.IsRankLowerThanOrSameAs(_card, _order);
        }
    }
}
