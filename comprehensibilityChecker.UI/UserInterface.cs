using System.Windows.Forms;
using comprehensibilityChecker.Contracts;
using comprehensibilityChecker.Contracts.Dtos;

namespace comprehensibilityChecker.UI
{
    public sealed class UserInterface : IUserInterfacePortal
    {
        private readonly MainViewModel _viewModel;

        public UserInterface(MainViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public bool AskUserForManuscriptFile(out string manuscriptFilePath)
        {
            var manuscriptFileDialog = new OpenFileDialog
            {
                Filter = "Text Files |*.txt",
                Title = "Manuscript auswählen"
            };
            manuscriptFileDialog.ShowDialog();
            manuscriptFilePath = manuscriptFileDialog.FileName;
            return !string.IsNullOrEmpty(manuscriptFilePath);
        }

        public void ShowResults(ComprehensibilityIndexDto dto)
        {
            _viewModel.AverageSentenceLengthNumber = dto.AverageSentenceLength;
            _viewModel.AverageWordLengthNumber = dto.AverageWordLength;
            _viewModel.WordCountNumber = dto.WordCount;
            _viewModel.ComprehensibilityIndex = dto.Comprehensibility;
        }
    }
}