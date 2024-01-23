﻿using CardGames.Core.Cards;
using CardGames.Core.Decks;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CardGames.Core.Tests.Decks
{
    public partial class DeckFactoryTests
    {
        static void VerifyDeckContainsAllStandardCards(Deck deck)
        {
            var suits = new[] { Suit.Hearts, Suit.Clubs, Suit.Diamonds, Suit.Spades };
            var ranks = new[]
            {
                Rank.Two,
                Rank.Three,
                Rank.Four,
                Rank.Five,
                Rank.Six,
                Rank.Seven,
                Rank.Eight,
                Rank.Nine,
                Rank.Ten,
                Rank.Jack,
                Rank.Queen,
                Rank.King,
                Rank.Ace
            };

            var expectedSuitRankCombinations = new List<(Suit suit, Rank rank)>();

            foreach (var suit in suits)
                foreach (var rank in ranks)
                    expectedSuitRankCombinations.Add((suit, rank));

            Assert.Multiple(expectedSuitRankCombinations
                .Select<(Suit suit, Rank rank), Action>(x => () => VerifyCard(x.suit, x.rank)).ToArray());

            void VerifyCard(Suit suit, Rank rank)
            {
                var matchingCards = deck.Cards.Where(card => card.Suit == suit && card.Rank == rank);

                matchingCards.ShouldHaveSingleItem($"Suit: {suit}, Rank: {rank}");
            }
        }
    }
}
