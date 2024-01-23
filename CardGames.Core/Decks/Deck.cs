using CardGames.Core.Cards;
using CardGames.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGames.Core.Decks
{
    public class Deck
    {
        readonly IRandomIntGenerator _random;
        readonly List<Card> _cards;

        public Deck(IRandomIntGenerator random, IEnumerable<Card> cards)
        {
            _random = random;
            _cards = cards.ToList();
        }

        public IReadOnlyList<Card> Cards => _cards.AsReadOnly();

        public void Add(Card card)
        {
            if (card == null)
                throw new ArgumentNullException(nameof(card));
            if (_cards.Contains(card))
                throw new InvalidOperationException("Card already in deck.");

            _cards.Add(card);
        }

        public Card DrawCard()
        {
            if (!_cards.Any()) throw new CannotDrawCardException();

            var card = _cards.First();
            _cards.Remove(card);

            return card;
        }

        public void Shuffle()
        {
            var remainingCards = _cards.ToList();
            _cards.Clear();

            while (remainingCards.Any())
            {
                var card = remainingCards.ElementAt(_random.Generate(0, remainingCards.Count));
                remainingCards.Remove(card);
                _cards.Add(card);
            }
        }
    }
}
