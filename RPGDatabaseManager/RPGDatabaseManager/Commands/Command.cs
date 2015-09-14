
using System;
using System.Windows.Input;

namespace RPGDatabaseManager.Commands
{
    public class Command : ICommand
    {
        private readonly Action<object> execute;
        private readonly Func<object, bool> canExecute;
        
        public Command(Action<object> execute) : this(execute, null) { }

        public Command(Action<object> execute, Func<object, bool> canExecute)
        {
            if (execute == null) throw new ArgumentNullException(nameof(execute));

            this.execute = execute;
            this.canExecute = canExecute ?? (x => true);
        }
         
        public bool CanExecute(object parameter)
        {
            return canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Refresh()
        {
            CommandManager.InvalidateRequerySuggested();
        }
    }
}