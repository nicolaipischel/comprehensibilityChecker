using comprehensibilityChecker.Contracts;
using FluentAssertions;
using Xunit;

namespace comprehensibilityChecker.Adapters.Test
{
    public class ManuscriptProviderTests
    {
        const string TestManuscriptFilePath = @"../../Files/TestManuscript.txt";

        private readonly IManuscriptProvider _target;

        public ManuscriptProviderTests()
        {
            _target = new ManuscriptProvider();
        }
        
        [Fact]
        public void LoadText_GivenValidFilePath_ShouldReturnTextFileContent()
        {
            var expected = @"Auf der Mauer, auf der Lauer sitzt eine kleine Wanze.
Seht euch mal die Wanze an, wie die Wanze tanze kann!
Auf der Mauer, auf der Lauer sitzt eine kleine Wanze.";

            var actual = _target.LoadText(TestManuscriptFilePath);

            actual.Should().BeEquivalentTo(expected);
        }
    }
}
