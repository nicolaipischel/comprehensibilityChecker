using System.IO;
using comprehensibilityChecker.Contracts;

namespace comprehensibilityChecker.Adapters
{
    internal sealed class ManuscriptProvider : IManuscriptProvider
    {
        public string LoadText(string filePath)
        {
            return File.ReadAllText(filePath);
        }
    }
}
