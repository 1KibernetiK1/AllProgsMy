using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectConsoleCommand.PatternCommand
{
    /// <summary>
    /// 3) шаг - заказчик действия
    /// в реальном проекте - кнопка на UI
    /// (Вызыватель - ничего не знает об исполнителе)
    /// </summary>
    public class invoker
    {
        private readonly CommandBase _command;

        /// <summary>
        /// Инъекция зависимости
        /// </summary>
        /// <param name="command"></param>
        public invoker(CommandBase command)
        {
            // _command - new Command1(); bad style
            _command = command;
        }

        public void Click()
        {
            _command.Execute();
        }
    }
}
