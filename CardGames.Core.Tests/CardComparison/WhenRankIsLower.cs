using CardGames.Core.Cards;
using CardGames.Core.Cards.Order;
using Xunit;

namespace CardGames.Core.Tests.CardComparison
{
    public class WhenRankIsLower
    {
        [Theory, MemberData(nameof(Cases))]
        public void Card_should_not_be_higher(Card card, Card other, CardOrder order)
        {
            Assert.False(
                card.IsRankHigherThan(other, order));
        }

        [Theory, MemberData(nameof(Cases))]
        public void Card_should_not_be_higher_or_same_(Card card, Card other, CardOrder order)
        {
            Assert.False(
                card.IsRankHigherThanOrSameAs(other, order));
        }

        [Theory, MemberData(nameof(Cases))]
        public void Card_should_be_lower(Card card, Card other, CardOrder order)
        {
            Assert.True(
                card.IsRankLowerThan(other, order));
        }

        [Theory, MemberData(nameof(Cases))]
        public void Card_should_be_lower_or_same(Card card, Card other, CardOrder order)
        {
            Assert.True(
                card.IsRankLowerThanOrSameAs(other, order));
        }

        public static readonly object[][] Cases =
        [
            [Card.FiveOfClubs, Card.EightOfClubs, CardOrder.AceIsHigh],

            [Card.FiveOfClubs, Card.AceOfDiamonds, CardOrder.AceIsHigh],

            [Card.TenOfClubs, Card.KingOfClubs, CardOrder.AceIsHigh],

            [Card.AceOfHearts, Card.FiveOfHearts, CardOrder.AceIsLow],

            [Card.AceOfHearts, Card.KingOfClubs, CardOrder.AceIsLow],
        ];
    }
}
