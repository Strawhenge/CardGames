using CardGames.Core.Cards;
using Shithead.Selection;
using Xunit;

namespace Shithead.Tests
{
    public class CardSelectionTests
    {
        [Fact]
        public void Selection_should_contain_card()
        {
            var card = Card.NineOfClubs;
            var selectableCard = new SelectableCard(card);

            var selection = selectableCard.CreateSelection();

            var result = Assert.Single(selection.Cards);
            Assert.Equal(card, result);
        }

        [Fact]
        public void Selection_should_contain_one_card_when_others_not_selected()
        {
            var card = Card.NineOfClubs;
            var others = new Card[] { Card.NineOfDiamonds, Card.NineOfHearts, Card.NineOfSpades };
            var selectableCard = new SelectableCard(card, canBeGroupedWith: others);

            var selection = selectableCard.CreateSelection();

            var result = Assert.Single(selection.Cards);
            Assert.Equal(card, result);
        }

        [Fact]
        public void Selection_should_have_groupable_cards_available()
        {
            var card = Card.NineOfClubs;
            var others = new Card[] { Card.NineOfDiamonds, Card.NineOfHearts, Card.NineOfSpades };
            var selectableCard = new SelectableCard(card, canBeGroupedWith: others);

            var selection = selectableCard.CreateSelection();

            Assert.Equal(3, selection.CanBeGroupedWith.Count);
        }

        [Fact]
        public void Selection_should_contain_grouped_cards()
        {
            var card = Card.NineOfClubs;
            var others = new Card[] { Card.NineOfDiamonds, Card.NineOfHearts, Card.NineOfSpades };
            var selectableCard = new SelectableCard(card, canBeGroupedWith: others);

            var selection = selectableCard.CreateSelection();

            selection.CanBeGroupedWith[0].AddToSelection();
            selection.CanBeGroupedWith[1].AddToSelection();

            var cards = selection.Cards;
            Assert.Equal(3, cards.Count);

            Assert.Equal(card, cards[0]);
            Assert.Equal(others[0], cards[1]);
            Assert.Equal(others[1], cards[2]);
        }
    }
}
