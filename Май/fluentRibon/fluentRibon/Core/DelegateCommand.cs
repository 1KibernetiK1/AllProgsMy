using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace fluentRibon.Core
{
    public class DelegateCommand : ICommand
    {
        public DelegateCommand(string commandTitle, Action executeMethod, Func<bool> canExecuteMethod)
            : this(executeMethod, canExecuteMethod)
        {
            CommandTitle = commandTitle;
        }


        public DelegateCommand(Action executeMethod, Func<bool> canExecuteMethod)
        {
            if (executeMethod == null)
            {
                throw new ArgumentNullException("executeMethod");
            }

            _executeMethod = executeMethod;
            _canExecuteMethod = canExecuteMethod;
        }

        public virtual bool CanExecute()
        {
            if (_canExecuteMethod != null)
            {
                return _canExecuteMethod();
            }
            return true;
        }

        public string CommandTitle
        {
            get;
            set;
        }

        public virtual void Execute()
        {
            var executeMethod = _executeMethod;
            executeMethod?.Invoke();
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute();
        }

        void ICommand.Execute(object parameter)
        {
            Execute();
        }

        private readonly Action _executeMethod = null;
        private readonly Func<bool> _canExecuteMethod = null;
    }
}
