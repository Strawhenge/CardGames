using CardGames.Core.Cards;

namespace Shithead.Rules
{
    public interface IRulesAccessor
    {
        bool IsInvisibleCard(Card card);

        bool IsReverseCard(Card card);
    }
}
