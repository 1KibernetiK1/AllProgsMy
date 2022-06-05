using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryCommand
{
    public class CommandManager
    {
        private List<ICommand> _commands;
        private List<ICommandBinder> _binders;
        public CommandManager()
        {
            _commands = new List<ICommand>();
            _binders = new List<ICommandBinder>()
            {
                new ControlBinder(),
                new MenuItemBinder()
            };
            Application.Idle += UpdateState;
        }

        private void UpdateState(object sender, EventArgs a)
        {
            _commands.Do(x => x.Enabled);
        }

        public void Bind(ICommand com, params IComponent[] items)
        {
            if (!_commands.Contains(com))
                _commands.Add(com);
            foreach (var c in items)
            {
                var binder = GetBinderFor(c);
                if (binder != null)
                    binder.Bind(com, c);
            }
        }

        /// <summary>
        /// Находим биндер для объекта
        /// </summary>
        /// <returns></returns>
        private ICommandBinder GetBinderFor(IComponent com)
        {
            var type = com.GetType();
            while (type != null)
            {
                var binder = _binders
                    .FirstOrDefault(x => x.SourceType == type);
                if (binder != null)
                    return binder;
                // если не нашли, то берём предка
                type = type.BaseType;
            }
            return null;
        }
    }

    public static class Helper
    {
        public static void Do<T>(this IEnumerable<T> col, 
                                 Func<T, object> f)
        {
            foreach (var item in col)
            {
                f(item);
            }
        }
    }

}
