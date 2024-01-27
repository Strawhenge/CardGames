using CardGames.Core.Cards;
using CardGames.Core.Cards.Order;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shithead.Rules
{
    public class GameRules : IRulesAccessor
    {
        IReadOnlyList<Rank> _anytimeRanks = Array.Empty<Rank>();
        Rank? _invisibleCardRank;
        Rank? _reverseCardRank;

        public CardOrder CardOrder => CardOrder.AceIsHigh;

        public bool IsAnytimeCard(Card card) => _anytimeRanks.Contains(card.Rank);

        public bool IsInvisibleCard(Card card) =>
            _invisibleCardRank.HasValue && card.Rank == _invisibleCardRank.Value;

        public bool IsReverseCard(Card card) =>
            _reverseCardRank.HasValue && card.Rank == _reverseCardRank.Value;

        public void SetAnytime(Rank rank)
        {
            _anytimeRanks = _anytimeRanks
                .Append(rank)
                .Distinct()
                .ToArray();
        }

        public void SetInvisible(Rank rank)
        {
            _invisibleCardRank = rank;
        }

        public void SetReverse(Rank rank)
        {
            _reverseCardRank = rank;
        }
    }
}
