using comprehensibilityChecker.Contracts;
using comprehensibilityChecker.Contracts.Data;
using FluentAssertions;
using Xunit;

namespace comprehensibilityChecker.Core.Test
{
    public class ManuscriptExtensionsTests
    {
        [Theory]
        [MemberData(nameof(ManuscriptExtensionsTestData.AverageSentenceLengthData), MemberType = typeof(ManuscriptExtensionsTestData))]
        public void GetAverageSentenceLength_GivenManuscript_ShouldReturnAverageSentenceLength(Manuscript manuscript, double expected)
        {
            var actual = ManuscriptExtensions.GetAverageSentenceLength(manuscript);
            actual.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(ManuscriptExtensionsTestData.AverageWordLengthData), MemberType = typeof(ManuscriptExtensionsTestData))]
        public void GetAverageWordLength_GivenManuscript_ShouldReturnAverageWordLength(Manuscript manuscript, double expected)
        {
            var actual = ManuscriptExtensions.GetAverageWordLength(manuscript);
            actual.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(ManuscriptExtensionsTestData.WordCountData), MemberType = typeof(ManuscriptExtensionsTestData))]
        public void GetWordCount_GivenManuscript_ShouldReturnWordCount(Manuscript manuscript, int expected)
        {
            var wordsToIgnore = new[] {"dein"};
            var actual = ManuscriptExtensions.GetWordCount(manuscript, wordsToIgnore);
            actual.Should().Be(expected);
        }
    }
}
