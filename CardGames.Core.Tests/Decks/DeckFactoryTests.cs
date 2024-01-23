using CardGames.Core.Cards;
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
    }
}