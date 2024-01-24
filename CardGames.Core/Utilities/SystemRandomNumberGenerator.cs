using System;

namespace CardGames.Core.Utilities
{
    public class SystemRandomNumberGenerator : IRandomIntGenerator
    {
        readonly Random _random = new Random();

        public int Generate(int minInclusive, int maxExclusive) =>
            _random.Next(minInclusive, maxExclusive);
    }
}
