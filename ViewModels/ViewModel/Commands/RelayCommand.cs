using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ViewModel.Commands
{
    public class RelayCommand : IRelayCommand
    {
        public event EventHandler CanExecuteChanged;
        private Action<object> _execute;
        private Predicate<object> _canExecute;

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

        public bool CanExecute(object parameter)
        {
            return _canExecute.Invoke(parameter);
        }

        public void Execute(object parameter)
        {
            _execute.Invoke(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
