using CardGames.Core.Cards;
using Shithead.Playability;
using Shithead.Rules;
using Xunit;

namespace Shithead.Tests.CardPlayabilityTests
{
    public class AnytimeCard
    {
        static readonly Rank[] AnytimeRanks = [Rank.Two, Rank.Three, Rank.Ten];

        readonly Wastepile _wastepile;
        readonly CardPlayability _cardplayability;

        public AnytimeCard()
        {
            _wastepile = new Wastepile();

            var rules = new GameRules();

            rules.SetAnytime(AnytimeRanks[0]);
            rules.SetAnytime(AnytimeRanks[1]);
            rules.SetAnytime(AnytimeRanks[2]);

            _cardplayability = new CardPlayability(rules, _wastepile);
        }

        [Fact]
        public void Should_be_playable_when_previous_card_is_higher()
        {
            _wastepile.Add(
                Card.TwoOfClubs,
                Card.JackOfDiamonds);

            Assert.Multiple(
                () =>
                {
                    Assert.True(
                        _cardplayability.CanPlay(Card.TwoOfHearts));
                },
                () =>
                {
                    Assert.True(
                        _cardplayability.CanPlay(Card.TwoOfHearts));
                },
                () =>
                {
                    Assert.True(
                        _cardplayability.CanPlay(Card.TenOfClubs));
                });
        }
    }
}
