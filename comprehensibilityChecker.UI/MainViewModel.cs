using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using comprehensibilityChecker.UI.Properties;

namespace comprehensibilityChecker.UI
{
    public sealed class MainViewModel : ViewModelBase
    {
        
        private double _averageSentenceLengthNumber;
        private double _averageWordLengthNumber;
        private double _comprehensibilityIndex;
        private int _wordCountNumber;

        public ICommand SelectManuscriptCommand { get; set; }

        public double AverageWordLengthNumber
        {
            get => _averageWordLengthNumber;
            set
            {
                _averageWordLengthNumber = value;
                OnPropertyChanged();
            }
        }

        public double AverageSentenceLengthNumber {
            get => _averageSentenceLengthNumber;
            set
            {
                _averageSentenceLengthNumber = value;
                OnPropertyChanged();
            }
        }

        public int WordCountNumber {
            get => _wordCountNumber;
            set
            {
                _wordCountNumber = value;
                OnPropertyChanged();
            }
        }

        public double ComprehensibilityIndex {
            get => _comprehensibilityIndex;
            set
            {
                _comprehensibilityIndex = value;
                OnPropertyChanged();
            }
        }
    }
}
