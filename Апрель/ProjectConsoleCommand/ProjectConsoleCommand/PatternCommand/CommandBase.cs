using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectConsoleCommand.PatternCommand
{

    /// <summary>
    /// 1) Шаг - базовая команда
    /// или абстр класс или интерфейс
    /// </summary>
    public abstract class CommandBase
    {
        public abstract void Execute();
        public abstract void Undo();
    }
}
