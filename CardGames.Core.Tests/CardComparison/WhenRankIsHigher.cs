using CardGames.Core.Cards;
using CardGames.Core.Cards.Order;
using Xunit;

namespace CardGames.Core.Tests.CardComparison
{

    public class WhenRankIsHigher
    {
        [Theory, MemberData(nameof(Cases))]
        public void Card_should_be_higher(Card card, Card other, CardOrder order)
        {
            Assert.True(
                card.IsRankHigherThan(other, order));
        }

        [Theory, MemberData(nameof(Cases))]
        public void Card_should_be_higher_or_same_(Card card, Card other, CardOrder order)
        {
            Assert.True(
                card.IsRankHigherThanOrSameAs(other, order));
        }

        [Theory, MemberData(nameof(Cases))]
        public void Card_should_not_be_lower(Card card, Card other, CardOrder order)
        {
            Assert.False(
                card.IsRankLowerThan(other, order));
        }

        [Theory, MemberData(nameof(Cases))]
        public void Card_should_not_be_lower_or_same(Card card, Card other, CardOrder order)
        {
            Assert.False(
                card.IsRankLowerThanOrSameAs(other, order));
        }

        public static readonly object[][] Cases =
        [
            [Card.EightOfClubs, Card.FiveOfClubs, CardOrder.AceIsHigh],

            [Card.AceOfDiamonds, Card.FiveOfClubs, CardOrder.AceIsHigh],

            [Card.KingOfClubs, Card.TenOfClubs, CardOrder.AceIsHigh],

            [Card.FiveOfClubs, Card.AceOfDiamonds, CardOrder.AceIsLow],

            [Card.KingOfClubs, Card.AceOfDiamonds, CardOrder.AceIsLow],
        ];
    }
}
