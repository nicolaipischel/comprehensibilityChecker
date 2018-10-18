using comprehensibilityChecker.Contracts.Dtos;

namespace comprehensibilityChecker.Contracts
{
    public interface IUserInterfacePortal
    {
        bool AskUserForManuscriptFile(out string manuscriptFilepath);

        void ShowResults(ComprehensibilityIndexDto dto);
    }
}
