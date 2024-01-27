﻿using CardGames.Core.Cards;
using CardGames.Core.Cards.Order;

namespace Shithead.Rules
{
    public interface IRulesAccessor
    {
        CardOrder CardOrder { get; }

        bool IsInvisibleCard(Card card);

        bool IsReverseCard(Card card);
    }
}