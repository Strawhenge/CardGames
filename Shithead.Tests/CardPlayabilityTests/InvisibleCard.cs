using CardGames.Core.Cards;
using Shithead.Playability;
using Shithead.Rules;
using Xunit;

namespace Shithead.Tests.CardPlayabilityTests
{

    public class InvisibleCard
    {
        const Rank InvisibleCardRank = Rank.Three;

        readonly Wastepile _wastepile;
        readonly CardPlayability _cardplayability;

        public InvisibleCard()
        {
            _wastepile = new Wastepile();

            var rules = new GameRules();
            rules.SetInvisible(InvisibleCardRank);

            _cardplayability = new CardPlayability(rules, _wastepile);
        }

        [Fact]
        public void Higher_card_than_before_invisible_should_be_playable()
        {
            _wastepile.Add(
                Card.NineOfClubs,
                Card.ThreeOfHearts);

            var card = Card.JackOfClubs;

            Assert.True(
                _cardplayability.CanPlay(card));
        }

        [Fact]
        public void Lower_card_than_before_invisible_should_not_be_playable()
        {
            _wastepile.Add(
                Card.NineOfClubs,
                Card.ThreeOfHearts);

            var card = Card.FiveOfClubs;

            Assert.False(
                _cardplayability.CanPlay(card));
        }
    }
}
