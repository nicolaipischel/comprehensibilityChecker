using System;
using System.Collections.Generic;
using System.Linq;
using comprehensibilityChecker.Contracts;
using comprehensibilityChecker.Contracts.Data;

namespace comprehensibilityChecker.Core
{
    public static class ManuscriptExtensions
    {
        public static double GetAverageSentenceLength(this Manuscript manuscript)
        {
            var textWithReplacedLineBreaks = ReplaceLineBreaksWithWhiteSpace(manuscript.OriginalText);
            double totalTextLength = textWithReplacedLineBreaks.Length;
            var sentenceCount = manuscript.Sentences.Count();
            var averageSentenceLength = GetAverageSentenceLength(totalTextLength, sentenceCount);
            return FormatNumber(averageSentenceLength);
        }

        public static double GetAverageWordLength(this Manuscript manuscript)
        {
            var relevantWords = GetRelevantWords(manuscript.Sentences);
            double totalWordLength = GetTotalWordLength(relevantWords);
            var averageWordLength = GetAverageWordLength(relevantWords, totalWordLength);
            return FormatNumber(averageWordLength);
        }

        public static int GetWordCount(this Manuscript manuscript, IEnumerable<string> wordsToIgnore)
        {
            var relevantWords = GetRelevantWords(manuscript.Sentences);
            var nonIgnoredWords = RemoveIgnoredWords(relevantWords, wordsToIgnore);
            return nonIgnoredWords.Count();
        }

        private static string ReplaceLineBreaksWithWhiteSpace(string text)
        {
            return text.Replace(Environment.NewLine, " ");
        }

        private static double FormatNumber(double number)
        {
            return Math.Round(number, 1);
        }

        private static double GetAverageSentenceLength(double totalTextLength, int sentenceCount)
        {
            return totalTextLength / sentenceCount;
        }

        private static double GetAverageWordLength(IEnumerable<string> words, double totalWordLength)
        {
            return totalWordLength / words.Count();
        }

        private static IEnumerable<string> GetWordsFromSentences(IEnumerable<Sentence> sentences)
        {
            return sentences.SelectMany(s => s.Words);
        }

        private static IEnumerable<string> OnlyWordsWithMoreThanThreeCharacters(IEnumerable<string> words)
        {
            return words.Where(w => w.Length > 3);
        }

        private static double GetTotalWordLength(IEnumerable<string> words)
        {
            return words.Select(w => w.Length).Sum();
        }

        private static IEnumerable<string> RemoveTerminatorsFromWords(IEnumerable<string> words)
        {
            var terminators = new[] { '.', '!', ',', '?', ';', '-' };
            return words.Select(
                w => new string(w.Where(c => !terminators.Contains(c)).ToArray()));
        }

        private static IEnumerable<string> GetRelevantWords(IEnumerable<Sentence> sentences)
        {
            var words = GetWordsFromSentences(sentences);
            var wordsWithoutTerminators = RemoveTerminatorsFromWords(words);
            var wordsWithMoreThan3Letters = OnlyWordsWithMoreThanThreeCharacters(wordsWithoutTerminators);
            return wordsWithMoreThan3Letters;
        }

        private static IEnumerable<string> RemoveIgnoredWords(
            IEnumerable<string> words,
            IEnumerable<string> wordsToIgnore)
        {
            return words.Where(word => !wordsToIgnore.Contains(word));
        }
    }
}