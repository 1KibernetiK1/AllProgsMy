using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCommand
{
    public abstract class CommandBase
        : ICommand
    {
        private bool _enabled;
        abstract public string Header { get; }

        public abstract bool CanExecute();

        public bool Enabled
        {
            get
            {
                if (_enabled == CanExecute())
                    return _enabled;
                _enabled = !_enabled;
                OnPropertyChanged("Enabled");
                return _enabled;
            }
        }

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, 
                new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        abstract public void Execute();
        
    }
}
