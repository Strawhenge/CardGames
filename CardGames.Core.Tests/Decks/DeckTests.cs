using CardGames.Core.Cards;
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
            _deckFactory = new DeckFactory(
                new CardShuffler(new SystemRandomNumberGenerator()));
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

        [Fact]
        public void Card_should_be_removed_from_deck_when_drawn()
        {
            var deck = _deckFactory.CreateDeckWithJokers();

            var card = deck.DrawCard();

            deck.Cards.ShouldNotContain(card);
        }

        [Fact]
        public void Card_should_be_at_bottom_of_deck_when_added()
        {
            var deck = _deckFactory.CreateDeckWithJokers();
            var card = Card.AceOfSpades;

            deck.Add(card);

            deck.Cards[deck.Cards.Count - 1].ShouldBe(card);
        }
    }
}
