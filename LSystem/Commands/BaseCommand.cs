using System;
using System.Windows.Input;

namespace LSystemVisual.Commands
{
    public abstract class BaseCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public BaseCommand()
        {
            CommandManager.RequerySuggested += CommandManager_RequerySuggested;
        }

        private void CommandManager_RequerySuggested(object sender, EventArgs e)
        {
            CanExecuteChanged?.Invoke(this, e);
        }

        public abstract bool CanExecute(object parameter);
        public abstract void Execute(object parameter);
    }
}
