using System;
using System.Windows.Input;

namespace FFTrainer
{
    public class DelegateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        Action<object> command;

        public DelegateCommand(Action<object> command)
        {
            this.command = command;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            command?.Invoke(parameter);
        }
    }
}