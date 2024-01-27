﻿using CardGames.Core.Cards;
using CardGames.Core.Cards.Order;
using System;

namespace Shithead.Rules
{
    public class GameRules : IRulesAccessor
    {
        Rank? invisibleCardRank;
        Rank? reverseCardRank;

        public CardOrder CardOrder => CardOrder.AceIsHigh;

        public bool IsInvisibleCard(Card card) =>
            invisibleCardRank.HasValue && card.Rank == invisibleCardRank.Value;

        public bool IsReverseCard(Card card) =>
            reverseCardRank.HasValue && card.Rank == reverseCardRank.Value;

        public void SetInvisible(Rank rank)
        {
            invisibleCardRank = rank;
        }

        public void SetReverse(Rank rank)
        {
            reverseCardRank = rank;
        }
    }
}