using CardGames.Core.Decks;
using Xunit;

namespace CardGames.Core.Tests.Decks
{
    public partial class DeckFactoryTests
    {
        readonly DeckFactory _deckFactory;

        public DeckFactoryTests()
        {
            _deckFactory = new DeckFactory();
        }

        [Fact]
        public void Deck_should_contain_52_cards()
        {
            var deck = _deckFactory.CreateDeck();

            Assert.Equal(52, deck.Cards.Count);
        }

        [Fact]
        public void Deck_should_contain_all_standard_cards()
        {
            var deck = _deckFactory.CreateDeck();

            VerifyDeckContainsAllStandardCards(deck);
        }

        [Fact]
        public void Deck_with_jokers_should_contain_54_cards()
        {
            var deck = _deckFactory.CreateDeckWithJokers();

            Assert.Equal(54, deck.Cards.Count);
        }

        [Fact]
        public void Deck_with_jokers_should_contain_all_standard_cards()
        {
            var deck = _deckFactory.CreateDeckWithJokers();

            VerifyDeckContainsAllStandardCards(deck);
        }

        [Fact]
        public void Deck_with_jokers_should_contain_both_jokers()
        {
            var deck = _deckFactory.CreateDeckWithJokers();

            VerifyDeckContainsBothJokers(deck);
        }
    }
}