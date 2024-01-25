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
        public void Invisible_card_should_always_be_playable()
        {
            _wastepile.Add(Card.TwoOfClubs);

            var card = Card.ThreeOfClubs;

            Assert.True(
                _cardplayability.CanPlay(card));

            _wastepile.Add(Card.NineOfClubs);

            Assert.True(
                _cardplayability.CanPlay(card));
        }
    }
}
