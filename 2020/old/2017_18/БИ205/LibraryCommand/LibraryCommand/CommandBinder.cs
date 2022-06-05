using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCommand
{
    public abstract class CommandBinder<T> :
        ICommandBinder where T : IComponent
    {
        public Type SourceType
        {
            get
            {
                return typeof(T);
            }
        }

        public void Bind(ICommand com, object source)
        {
            Bind(com, (T) source);
        }

        protected abstract void Bind(ICommand com, T source); 
    }
}
