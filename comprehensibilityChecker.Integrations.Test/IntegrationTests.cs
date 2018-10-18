using comprehensibilityChecker.Adapters;
using comprehensibilityChecker.Contracts;
using comprehensibilityChecker.Contracts.Dtos;
using NSubstitute;
using Xunit;

namespace comprehensibilityChecker.Integrations.Test
{
    public class IntegrationTests
    {
        private readonly IUserInterfacePortal _userInterfacePortal;
        private readonly IManuscriptProvider _manuscriptProvider;
        private readonly IStopWordProvider _stopWordProvider;
        private readonly Integration _target;

        const string TestManuscriptPath = @"../../Files/TestManuscript.txt";
        const string TestStopwordListPath = @"../../Files/TestStopWordList.txt";

        public IntegrationTests()
        {
            _userInterfacePortal = Substitute.For<IUserInterfacePortal>();
            _manuscriptProvider = new ManuscriptProvider();
            _stopWordProvider = new StopwordProvider(TestStopwordListPath);

            _target = new Integration(
                _userInterfacePortal,
                _manuscriptProvider,
                _stopWordProvider);
        }

        [Fact]
        public void AcceptanceTest()
        {
            var expectedAverageSentenceLength = 53.7;
            var expectedAverageWordLength = 4.8;
            var expectedWordCount = 16;
            var expectedComprehensibility = 6.9922;

            string manuscriptPath;
            _userInterfacePortal.AskUserForManuscriptFile(
                out manuscriptPath).Returns(
                callInfo =>
                {
                    callInfo[0] = TestManuscriptPath;
                    return true;
                });

            _target.Run();

            _userInterfacePortal.Received(1).ShowResults(Arg.Is(
                (ComprehensibilityIndexDto dto) =>
                    dto.Comprehensibility == expectedComprehensibility
                      && dto.AverageSentenceLength == expectedAverageSentenceLength
                      && dto.AverageWordLength == expectedAverageWordLength
                      && dto.WordCount == expectedWordCount));
        }

        [Fact]
        public void AcceptanceTest_IfUserHasNotSelectedFile()
        {
            string manuscriptPath;
            _userInterfacePortal.AskUserForManuscriptFile(
                out manuscriptPath).Returns(
                callInfo =>
                {
                    callInfo[0] = string.Empty;
                    return false;
                });

            _target.Run();

            _userInterfacePortal.DidNotReceive().ShowResults(Arg.Any<ComprehensibilityIndexDto>());
        }
    }
}