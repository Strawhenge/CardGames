using CardGames.Core.Cards;
using Shithead.CardCollections;
using Xunit;

namespace Shithead.Tests
{
    public class ArrangeStartingCardsTests
    {
        [Fact]
        public void No_swapping_should_return_same_card_positions()
        {
            var startingCards = CreateStartingCards();

            var arrange = new ArrangeStartingCards(startingCards);

            var newStartingCards = arrange.Finish();

            Assert.Multiple(
                () => Assert.Same(startingCards.FaceUp.First, newStartingCards.FaceUp.First),
                () => Assert.Same(startingCards.InHand.First, newStartingCards.InHand.First),
                () => Assert.Same(startingCards.FaceUp.Second, newStartingCards.FaceUp.Second),
                () => Assert.Same(startingCards.InHand.Second, newStartingCards.InHand.Second),
                () => Assert.Same(startingCards.InHand.Third, newStartingCards.InHand.Third),
                () => Assert.Same(startingCards.InHand.Third, newStartingCards.InHand.Third)
                );
        }

        [Fact]
        public void Swapping_face_down_cards_with_in_hand_cards_should_return_them_swapped()
        {
            var startingCards = CreateStartingCards();

            var arrange = new ArrangeStartingCards(startingCards);

            arrange.FirstFaceUp.SwapWithThirdInHand();
            arrange.ThirdFaceUp.SwapWithSecondInHand();

            var newStartingCards = arrange.Finish();

            Assert.Multiple(
                () =>
                {
                    Assert.Same(startingCards.FaceUp.First, newStartingCards.InHand.Third);
                },
                () =>
                {
                    Assert.Same(startingCards.InHand.Third, newStartingCards.FaceUp.First);
                },
                () =>
                {
                    Assert.Same(startingCards.FaceUp.Third, newStartingCards.InHand.Second);
                },
                () =>
                {
                    Assert.Same(startingCards.InHand.Second, newStartingCards.FaceUp.Third);
                });
        }

        static StartingCards CreateStartingCards()
        {
            return new StartingCards(
                faceDown: new ThreeCards(Card.AceOfClubs, Card.EightOfClubs, Card.FiveOfHearts),
                faceUp: new ThreeCards(Card.SixOfClubs, Card.KingOfClubs, Card.NineOfClubs),
                inHand: new ThreeCards(Card.FourOfSpades, Card.TenOfClubs, Card.AceOfClubs)
                );
        }
    }
}
