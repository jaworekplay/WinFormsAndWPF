using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ViewModel.Commands
{
    public class RelayCommand : ICommand
    {
        Action<object> _execute;
        Predicate<object> _canExecute;

        public RelayCommand(Action<object> execute)
        {
            _execute = execute;
            _canExecute = (o) => true;
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _canExecute.Invoke(parameter);
        }

        public void Execute(object parameter)
        {
            _execute.Invoke(parameter);
        }
    }
}
