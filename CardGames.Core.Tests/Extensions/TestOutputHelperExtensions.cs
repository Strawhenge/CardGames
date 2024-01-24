using CardGames.Core.Cards;
using CardGames.Core.Decks;
using Xunit.Abstractions;

namespace CardGames.Core.Tests
{
    static class TestOutputHelperExtensions
    {
        static readonly CardNames _cardNames = new CardNames();

        internal static void OutputDeck(this ITestOutputHelper outputHelper, Deck deck)
        {
            foreach (var card in deck.Cards)
                outputHelper.WriteLine(_cardNames.GetName(card));
        }
    }
}
