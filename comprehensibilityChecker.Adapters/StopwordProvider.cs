using System.Collections.Generic;
using System.IO;
using comprehensibilityChecker.Contracts;

namespace comprehensibilityChecker.Adapters
{
    internal sealed class StopwordProvider : IStopWordProvider
    {
        private readonly string _filePath;
        public StopwordProvider(string filePath)
        {
            this._filePath = filePath;
        }
        public IEnumerable<string> LoadStopWords()
        {
            return File.ReadAllLines(_filePath);
        }
    }
}
