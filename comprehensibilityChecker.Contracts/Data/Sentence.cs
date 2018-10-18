using System.Collections.Generic;

namespace comprehensibilityChecker.Contracts
{
    public sealed class Sentence
    {
        public Sentence(IEnumerable<string> words)
        {
            Words = words;
        }

        public IEnumerable<string> Words { get; }
    }
}
