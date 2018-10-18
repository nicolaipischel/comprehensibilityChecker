using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace comprehensibilityChecker.Core.Test
{
    public class ParserTests
    {
        [Fact]
        public void Parse_GivenText_ShouldReturnManuscript()
        {
            var input = @"Es blaut die Nacht, die Sternlein blinken.
                          Schneeflöcklein leis herunter sinken.";

            var expected = TestHelper.CreateFilledManuscriptForSplitting();

            var actual = Parser.Parse(input);

            for (int i = 0; i < expected.Sentences.Count(); i++)
            {
                var expectedWords = expected.Sentences.ToArray()[i].Words;
                var actualWords = actual.Sentences.ToArray()[i].Words;
                
                actualWords.Should().BeEquivalentTo(expectedWords);
            }
        }

        [Fact]
        public void SplitIntoSentences_GivenTextContainingTerminators_ShouldSplitToSentences()
        {
            var input = "Hallo wie geht es dir? Mir geht es gut. Vorsicht ein Waschbär!";

            var expected = new[] { "Hallo wie geht es dir?", "Mir geht es gut.", "Vorsicht ein Waschbär!" };

            var actual = Parser.SplitIntoSentences(input);

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void SplitIntoSentences_GivenTextContainingNoTerminators_ShouldReturnTextWithReplacedLineBreaks()
        {
            var input = $"Hallo{Environment.NewLine}wie geht es{Environment.NewLine}dir";

            var expected = new[] {"Hallo wie geht es dir"};

            var actual = Parser.SplitIntoSentences(input);

            actual.Should().BeEquivalentTo(expected);
        }


    }
}
