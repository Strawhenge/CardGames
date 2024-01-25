using CardGames.Core.Cards;

namespace Shithead.Rules
{
    public class GameRules : IRulesAccessor
    {
        Rank? reverseCardRank;

        public bool IsReverseCard(Card card) =>
            reverseCardRank.HasValue && card.Rank == reverseCardRank.Value;

        public void SetReverse(Rank rank)
        {
            reverseCardRank = rank;
        }
    }
}
