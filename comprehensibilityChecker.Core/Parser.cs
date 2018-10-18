using System;
using System.Collections.Generic;
using System.Linq;
using comprehensibilityChecker.Contracts;
using comprehensibilityChecker.Contracts.Data;

namespace comprehensibilityChecker.Core
{
    public static class Parser
    {
        public static Manuscript Parse(string text)
        {
            return new Manuscript(
                        ParseSentences(), text);

            IEnumerable<Sentence> ParseSentences()
            {
                var sentenceTexts = SplitIntoSentences(text);
                return sentenceTexts.Select(sT => BuildSentence(sT));
            }
        }

        internal static IEnumerable<string> SplitIntoSentences(string text)
        {
            // TODO: Loesungsansatz ueberarbeiten (z.B. Rekursion)
            var sentenceSeparators = new[] { '.', '?', '!' };

            var textWithoutLineBreaks = text.Replace(Environment.NewLine, " ");

            if (TextDoesNotContainSeparators(textWithoutLineBreaks, sentenceSeparators))
            {
                return new[] { textWithoutLineBreaks };
            }

            var sentencesWithoutTerminators = textWithoutLineBreaks.Split(
                sentenceSeparators, 
                StringSplitOptions.RemoveEmptyEntries);

            return sentencesWithoutTerminators.Select(
                s => AddTerminatorToSentence(s, textWithoutLineBreaks));
        }

        private static bool TextDoesNotContainSeparators(string text, char[] sentenceSeparators)
        {
            return text.IndexOfAny(sentenceSeparators) == -1;
        }

        private static string AddTerminatorToSentence(string sentenceWithoutTerminator, string text)
        {
            var sentencePosition = text.IndexOf(sentenceWithoutTerminator, StringComparison.Ordinal);
            var characters = text.Trim().ToCharArray();
            var terminator = GetTerminatorForSentence(characters, sentencePosition, sentenceWithoutTerminator);
            var sentenceWithAddedTerminator = $"{sentenceWithoutTerminator}{terminator}";

            return sentenceWithAddedTerminator.Trim();

        }

        private static char GetTerminatorForSentence(char[] characters, int sentencePosition, string sentence)
        {
            var terminatorPosition = sentencePosition + sentence.Length;
            return characters[terminatorPosition];
        }

        private static Sentence BuildSentence(string sentence)
        {
            var words = sentence.Split(' ');
            return new Sentence(words);
        }
    }
}
