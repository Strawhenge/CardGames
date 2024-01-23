using CardGames.Core.Decks;
using Xunit.Abstractions;

namespace CardGames.Core.Tests
{
    static class TestOutputHelperExtensions
    {
        internal static void OutputDeck(this ITestOutputHelper outputHelper, Deck deck)
        {
            foreach (var card in deck.Cards)
                outputHelper.WriteLine($"Suit: {card.Suit}, Rank: {card.Rank}");
        }
    }
}
