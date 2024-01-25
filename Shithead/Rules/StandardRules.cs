namespace Shithead.Rules
{
    public class StandardRules : IRules
    {
        public static IRules Instance { get; } = new StandardRules();

        private StandardRules()
        {
        }
    }
}
