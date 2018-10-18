namespace comprehensibilityChecker.Contracts.Dtos
{
    public class ComprehensibilityIndexDto
    {
        public ComprehensibilityIndexDto(
            double averageSentenceLength, 
            double averageWordLength, 
            int wordCount, 
            double comprehensibility)
        {
            AverageSentenceLength = averageSentenceLength;
            AverageWordLength = averageWordLength;
            WordCount = wordCount;
            Comprehensibility = comprehensibility;
        }
        public double AverageSentenceLength { get; }
        public double AverageWordLength { get; }
        public int WordCount { get; }
        public double Comprehensibility { get; }
    }
}