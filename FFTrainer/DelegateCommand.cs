using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FFTrainer
{
    public class DelegateCommand : ICommand
    {
        #pragma warning disable CS00067 
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