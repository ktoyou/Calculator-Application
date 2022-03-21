using System;
using System.Windows.Input;

namespace Calculator.Commands
{
    internal class RelayCommand : BaseCommand
    {
        public RelayCommand(Action<object> execute, bool canExecute)
        {
            _execute = execute;
            CanExecuteCommand = canExecute;
        }

        public override void ExecuteCommand(object parameter) => _execute(parameter);

        private Action<object> _execute;
    }
}
