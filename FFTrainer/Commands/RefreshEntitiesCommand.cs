using System;
using FFTrainer.ViewModels;
using System.Windows.Input;
namespace FFTrainer.Commands
{
    public class RefreshEntitiesCommand : ICommand
    {
        private CharacterDetailsViewModel entityListViewModel;
        public event EventHandler CanExecuteChanged;

        public RefreshEntitiesCommand(CharacterDetailsViewModel vm)
        {
            entityListViewModel = vm;
        }

        public bool CanExecute(object parameter)
        {
            return MemoryManager.Instance.IsReady();
        }

        public void Execute(object parameter)
        {
            entityListViewModel.Refresh();
        }
    }
}
