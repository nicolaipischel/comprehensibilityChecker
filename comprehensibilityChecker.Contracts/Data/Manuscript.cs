using System.Collections.Generic;

namespace comprehensibilityChecker.Contracts.Data
{
    public sealed class Manuscript
    {
        public Manuscript(IEnumerable<Sentence> sentences, string originalText)
        {
            Sentences = sentences;
            OriginalText = originalText;
        }

        public string OriginalText { get; }

        public IEnumerable<Sentence> Sentences { get; }

    }
}
