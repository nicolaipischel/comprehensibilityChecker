using System.Collections.Generic;
using comprehensibilityChecker.Contracts;
using comprehensibilityChecker.Contracts.Data;
using comprehensibilityChecker.Contracts.Dtos;
using comprehensibilityChecker.Core;

namespace comprehensibilityChecker.Integrations
{
    public sealed class Integration
    {
        private readonly IUserInterfacePortal _userInterfacePortal;
        private readonly IManuscriptProvider _manuscriptProvider;
        private readonly IStopWordProvider _stopWordProvider;

        public Integration(
            IUserInterfacePortal userInterfacePortal,
            IManuscriptProvider manuscriptProvider,
            IStopWordProvider stopWordProvider)
        {
            _userInterfacePortal = userInterfacePortal;
            _manuscriptProvider = manuscriptProvider;
            _stopWordProvider = stopWordProvider;
        }

        public void Run()
        {
            if (!_userInterfacePortal.AskUserForManuscriptFile(out var manuscriptFilePath)) { return ;}

            var manuscript = GetManuscript(manuscriptFilePath);
            var wordsToIgnore = _stopWordProvider.LoadStopWords();
           
            var comprehensibilityIndex = CalculateComprehensibilityIndex(manuscript, wordsToIgnore);

            _userInterfacePortal.ShowResults(comprehensibilityIndex);
        }

        private Manuscript GetManuscript(string manuscriptFilePath)
        {
            var text = _manuscriptProvider.LoadText(manuscriptFilePath);
            var manuscript = Parser.Parse(text);
            return manuscript;
        }

        private ComprehensibilityIndexDto CalculateComprehensibilityIndex(Manuscript manuscript, IEnumerable<string> wordsToIgnore)
        {
            var averageWordLength = manuscript.GetAverageWordLength();
            var averageSentenceLength = manuscript.GetAverageSentenceLength();
            var wordCount = manuscript.GetWordCount(wordsToIgnore);

            var comprehensibility = Calculator.CalculateComprehensibility(
                averageSentenceLength, 
                averageWordLength, 
                wordCount);

            return new ComprehensibilityIndexDto(
                averageSentenceLength,
                averageWordLength,
                wordCount,
                comprehensibility);
        }
    }
}