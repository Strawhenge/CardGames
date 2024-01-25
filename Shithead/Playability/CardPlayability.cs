using CardGames.Core.Cards;
using Shithead.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shithead.Playability
{
    public class CardPlayability
    {
        readonly IRulesAccessor _rules;
        readonly Wastepile _wastepile;
        State _state = new EmptyWastepile();

        public CardPlayability(IRulesAccessor rules, Wastepile wastepile)
        {
            _rules = rules;
            _wastepile = wastepile;
            _wastepile.Cleared += OnWastepileCleared;
            _wastepile.Added += OnAddedToWastepile;
        }

        public bool CanPlay(Card card)
        {
            if (_rules.IsInvisibleCard(card))
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
                _state = State.MustBeLowerOrEqualTo(card.Rank);
                return;
            }

            _state = State.MustBeHigherOrEqualTo(card.Rank);
        }
    }
}
