using CardGames.Core.Cards;
using CardGames.Core.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace CardGames.Core.Decks
{
    public class DeckFactory
    {
        readonly IRandomIntGenerator _random;

        public DeckFactory(IRandomIntGenerator random)
        {
            _random = random;
        }

        public Deck CreateDeck()
        {
            var cards = GetAllStandardCards();

            return new Deck(_random, cards);
        }

        public Deck CreateDeckWithJokers()
        {
            var cards = GetAllStandardCards().Concat(GetJokers());

            return new Deck(_random, cards);
        }

        static IEnumerable<Card> GetAllStandardCards()
        {
            yield return Card.TwoOfHearts;
            yield return Card.ThreeOfHearts;
            yield return Card.FourOfHearts;
            yield return Card.FiveOfHearts;
            yield return Card.SixOfHearts;
            yield return Card.SevenOfHearts;
            yield return Card.EightOfHearts;
            yield return Card.NineOfHearts;
            yield return Card.TenOfHearts;
            yield return Card.JackOfHearts;
            yield return Card.QueenOfHearts;
            yield return Card.KingOfHearts;
            yield return Card.AceOfHearts;
            yield return Card.TwoOfClubs;
            yield return Card.ThreeOfClubs;
            yield return Card.FourOfClubs;
            yield return Card.FiveOfClubs;
            yield return Card.SixOfClubs;
            yield return Card.SevenOfClubs;
            yield return Card.EightOfClubs;
            yield return Card.NineOfClubs;
            yield return Card.TenOfClubs;
            yield return Card.JackOfClubs;
            yield return Card.QueenOfClubs;
            yield return Card.KingOfClubs;
            yield return Card.AceOfClubs;
            yield return Card.TwoOfDiamonds;
            yield return Card.ThreeOfDiamonds;
            yield return Card.FourOfDiamonds;
            yield return Card.FiveOfDiamonds;
            yield return Card.SixOfDiamonds;
            yield return Card.SevenOfDiamonds;
            yield return Card.EightOfDiamonds;
            yield return Card.NineOfDiamonds;
            yield return Card.TenOfDiamonds;
            yield return Card.JackOfDiamonds;
            yield return Card.QueenOfDiamonds;
            yield return Card.KingOfDiamonds;
            yield return Card.AceOfDiamonds;
            yield return Card.TwoOfSpades;
            yield return Card.ThreeOfSpades;
            yield return Card.FourOfSpades;
            yield return Card.FiveOfSpades;
            yield return Card.SixOfSpades;
            yield return Card.SevenOfSpades;
            yield return Card.EightOfSpades;
            yield return Card.NineOfSpades;
            yield return Card.TenOfSpades;
            yield return Card.JackOfSpades;
            yield return Card.QueenOfSpades;
            yield return Card.KingOfSpades;
            yield return Card.AceOfSpades;
        }

        static IEnumerable<Card> GetJokers()
        {
            yield return Card.RedJoker;
            yield return Card.BlackJoker;
        }
    }
}
