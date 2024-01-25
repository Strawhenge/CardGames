using CardGames.Core.Cards;
using Shithead.Playability;
using Shithead.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Shithead.Tests.CardPlayabilityTests
{
    public class ReverseCard
    {
        const Rank ReverseCardRank = Rank.Seven;

        readonly Wastepile _wastepile;
        readonly CardPlayability _cardplayability;

        public ReverseCard()
        {
            _wastepile = new Wastepile();

            var rules = new GameRules();
            rules.SetReverse(ReverseCardRank);

            _cardplayability = new CardPlayability(rules, _wastepile);
        }

        [Fact]
        public void Card_with_same_rank_should_be_playable()
        {
            _wastepile.Add(
                Card.FourOfClubs,
                Card.SevenOfDiamonds);

            var card = Card.SevenOfHearts;

            Assert.True(
                _cardplayability.CanPlay(card));
        }

        [Fact]
        public void Higher_card_should_not_be_playable()
        {
            _wastepile.Add(
                Card.FourOfClubs,
                Card.SevenOfDiamonds);

            var card = Card.EightOfSpades;

            Assert.False(
                _cardplayability.CanPlay(card));
        }

        [Fact]
        public void Lower_card_should_be_playable()
        {
            _wastepile.Add(
                Card.FourOfClubs,
                Card.SevenOfDiamonds);

            var card = Card.FiveOfHearts;

            Assert.True(
                _cardplayability.CanPlay(card));
        }
    }
}
