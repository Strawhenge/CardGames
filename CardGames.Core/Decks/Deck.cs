using CardGames.Core.Cards;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGames.Core.Decks
{
    public class Deck
    {
        readonly ICardShuffler _shuffler;
        readonly List<Card> _cards;

        public Deck(ICardShuffler shuffler, IEnumerable<Card> cards)
        {
            _shuffler = shuffler;
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
            var newCardOrder = _shuffler.Shuffle(_cards);
            _cards.Clear();
            _cards.AddRange(newCardOrder);
        }
    }
}
