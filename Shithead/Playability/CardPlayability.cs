using CardGames.Core.Cards;
using Shithead.Rules;

namespace Shithead.Playability
{
    public class CardPlayability
    {
        readonly IRulesAccessor _rules;
        readonly Wastepile _wastepile;
        State _state = State.EmptyWastepile;

        public CardPlayability(IRulesAccessor rules, Wastepile wastepile)
        {
            _rules = rules;
            _wastepile = wastepile;
            _wastepile.Cleared += OnWastepileCleared;
            _wastepile.Added += OnAddedToWastepile;
        }

        public bool CanPlay(Card card)
        {
            if (_rules.IsAnytimeCard(card))
                return true;

            return _state.CanPlay(card);
        }

        void OnWastepileCleared() => _state = State.EmptyWastepile;

        void OnAddedToWastepile(Card card)
        {
            if (_rules.IsInvisibleCard(card))
                return;

            if (_rules.IsReverseCard(card))
            {
                _state = State.MustBeLowerOrEqualTo(card, _rules.CardOrder);
                return;
            }

            _state = State.MustBeHigherOrEqualTo(card, _rules.CardOrder);
        }
    }
}
