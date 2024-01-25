using CardGames.Core.Cards;
using Shithead.Playability;
using Shithead.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Shithead.Tests
{
    public class CardPlayabilityTests
    {
        readonly Wastepile _wastepile;
        readonly CardPlayability _cardplayability;

        public CardPlayabilityTests()
        {
            _wastepile = new Wastepile();
            _cardplayability = new CardPlayability(StandardRules.Instance, _wastepile);
        }

        [Fact]
        public void Card_should_be_playable_when_wastepile_is_empty()
        {
            var card = Card.EightOfHearts;

            Assert.True(
                _cardplayability.CanPlay(card));
        }

        [Fact]
        public void Card_with_same_rank_as_last_should_be_playable()
        {
            _wastepile.Add(
               Card.FourOfClubs,
               Card.FiveOfDiamonds);

            var card = Card.FiveOfClubs;

            Assert.True(
                _cardplayability.CanPlay(card));
        }

        [Fact]
        public void Card_lower_than_last_played_should_not_be_playable()
        {
            _wastepile.Add(
                 Card.FourOfClubs,
                 Card.SevenOfClubs);

            var card = Card.FiveOfClubs;

            Assert.False(
                _cardplayability.CanPlay(card));
        }

        [Fact]
        public void Card_higher_than_last_played_should_be_playable()
        {
            _wastepile.Add(
                 Card.FourOfClubs,
                 Card.SevenOfClubs);

            var card = Card.EightOfSpades;

            Assert.True(
                _cardplayability.CanPlay(card));
        }
    }
}
