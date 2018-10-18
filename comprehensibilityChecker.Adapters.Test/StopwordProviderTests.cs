using System.Collections.Generic;
using comprehensibilityChecker.Contracts;
using FluentAssertions;
using Xunit;

namespace comprehensibilityChecker.Adapters.Test
{
    public class StopWordProviderTests
    {
        private const string TestStopWordListFilePath = @"../../Files/TestStopWordList.txt";

        private readonly IStopWordProvider _target;
        public StopWordProviderTests()
        {
            _target = new StopwordProvider(TestStopWordListFilePath);
        }

        [Fact]
        public void LoadStopWords_GivenValidFilePath_ShouldReturnStopWordListFileContent()
        {
            IEnumerable<string> expected = new[] {"Hallo", "das", "ist", "eine", "Teststopwortliste"};

            var actual = _target.LoadStopWords();

            actual.Should().BeEquivalentTo(expected);
        }
    }
}
