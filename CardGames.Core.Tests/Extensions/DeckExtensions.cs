using CardGames.Core.Cards;
using CardGames.Core.Decks;
using Shouldly;
using Xunit;

namespace CardGames.Core.Tests
{
    static class DeckExtensions
    {
        internal static void VerifyContainsAllStandardCardsOnce(this Deck deck)
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

            Assert.Multiple(expectedSuitRankCombinations.Select<(Suit suit, Rank rank), Action>(
                x => () => VerifyOneCardInDeck(deck, x.suit, x.rank)).ToArray());
        }

        internal static void VerifyContainsBothJokersOnce(this Deck deck)
        {
            Assert.Multiple(
                () => VerifyOneCardInDeck(deck, Suit.RedJoker, Rank.Joker),
                () => VerifyOneCardInDeck(deck, Suit.BlackJoker, Rank.Joker));
        }

        static void VerifyOneCardInDeck(Deck deck, Suit suit, Rank rank)
        {
            var matchingCards = deck.Cards.Where(card => card.Suit == suit && card.Rank == rank);

            matchingCards.ShouldHaveSingleItem($"Suit: {suit}, Rank: {rank}");
        }
    }
}
