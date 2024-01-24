namespace CardGames.Core.Utilities
{
    public interface IRandomIntGenerator
    {
        public int Generate(int minInclusive, int maxExclusive);
    }
}
