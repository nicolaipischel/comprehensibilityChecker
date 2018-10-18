using FluentAssertions;
using Xunit;

namespace comprehensibilityChecker.Core.Test
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(10.0, 5.0, 1500, 0.0133)]
        [InlineData(15.0, 6.0, 3000, 0.0083)]
        [InlineData(7.0, 5.0, 500, 0.028)]
        [InlineData(36.0, 8.66666666666666661, 9, 4.6154)]
        [InlineData(53.666666666666664, 4.833333333333333, 9, 12.3372)]
        internal void CalculateComprehensibility_GivenSentenceLengthWordLengthWordCount_ShouldReturnComprehensibilityIndex(
            double sentenceLength,
            double wordLength,
            int wordCount,
            double expected)
        {
            var actual = Calculator.CalculateComprehensibility(
                sentenceLength,
                wordLength,
                wordCount);

            actual.Should().Be(expected);
        }
    }
}
