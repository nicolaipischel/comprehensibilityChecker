using System;

namespace comprehensibilityChecker.Core
{
    public static class Calculator
    {
        public static double CalculateComprehensibility(double sentenceLength, double wordLength, int wordCount)
        {
            var dividedWordCount =(wordCount / 10.0f);
            var comprehensibility = sentenceLength / wordLength / dividedWordCount;
            return Math.Round(comprehensibility, 4, MidpointRounding.AwayFromZero);
        }
    }
}