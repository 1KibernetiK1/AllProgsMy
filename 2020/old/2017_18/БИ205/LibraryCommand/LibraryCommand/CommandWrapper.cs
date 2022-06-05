using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCommand
{
    public class CommandWrapper
        : CommandBase
    {
        private string _header;
        private Action _execute;
        private Func<bool> _enabled;

        public CommandWrapper(string header,
                              Func<bool> enabled,
                              Action execute)
        {
            _header = header;
            _enabled = enabled;
            _execute = execute;
        }

        public override bool CanExecute()
        {
            return _enabled();
        }

        public override void Execute()
        {
            _execute();
        }

        public override string Header
        {
            get
            {
                return _header;
            }
        }
    }
}
