using System;
using System.Windows.Input;

namespace comprehensibilityChecker.WPF
{
    public class ActionCommand<T> : ICommand
    {
        private readonly Action<T> _executeHandler;
        private readonly Predicate<T> _canExecuteHandler;
        
        public ActionCommand(Action<T> execute)
        {
            _executeHandler = execute ?? throw new ArgumentNullException("Execute cannot be null");
        }

        public ActionCommand(Action<T> execute, Predicate<T> canExecute)
            : this(execute)
        {
            _canExecuteHandler = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _executeHandler((T)parameter);
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecuteHandler == null)
                return true;
            return _canExecuteHandler((T)parameter);
        }
    }
}
