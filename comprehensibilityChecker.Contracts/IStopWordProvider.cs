using System.Collections.Generic;

namespace comprehensibilityChecker.Contracts
{
    public interface IStopWordProvider
    {
        IEnumerable<string> LoadStopWords();
    }
}
