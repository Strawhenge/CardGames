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
        readonly IRules _rules;
        readonly Wastepile _wastepile;
        State _state = new EmptyWastepile();

        public CardPlayability(IRules rules, Wastepile wastepile)
        {
            _rules = rules;
            _wastepile = wastepile;
            _wastepile.Cleared += OnWastepileCleared;
            _wastepile.Added += OnAddedToWastepile;
        }

        public bool CanPlay(Card card) => _state.CanPlay(card);

        void OnWastepileCleared() => _state = State.EmptyWastepile;

        void OnAddedToWastepile(Card card)
        {
            _state = State.MustBeHigherOrEqualTo(card.Rank);
        }
    }
}
