using CardGames.Core.Decks;
using CardGames.Core.Utilities;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace CardGames.Core.Tests.Decks
{
    public class DeckTests
    {
        readonly DeckFactory _deckFactory;
        readonly ITestOutputHelper _testOutputHelper;

        public DeckTests(ITestOutputHelper testOutputHelper)
        {
            _deckFactory = new DeckFactory(new SystemRandomNumberGenerator());
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void Full_deck_should_remain_full_when_shuffled()
        {
            var deck = _deckFactory.CreateDeckWithJokers();
            var originalCards = deck.Cards.ToArray();

            deck.Shuffle();

            _testOutputHelper.WriteLine("New deck order:");
            _testOutputHelper.OutputDeck(deck);

            deck.Cards.ShouldBe(originalCards, ignoreOrder: true);
        }
    }
}
