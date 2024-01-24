using CardGames.Core.Cards;
using System.Collections.Generic;

namespace CardGames.Core.Decks
{
    public interface ICardShuffler
    {
        IReadOnlyList<Card> Shuffle(IReadOnlyList<Card> cards);
    }
}
