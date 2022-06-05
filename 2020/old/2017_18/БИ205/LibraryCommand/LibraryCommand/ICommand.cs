using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCommand
{
    public interface ICommand : INotifyPropertyChanged
    {
        /// <summary>
        /// Заголовок команды
        /// </summary>
        string Header { get; }

        /// <summary>
        /// Доступна ли команда?
        /// </summary>
        bool Enabled { get; }

        /// <summary>
        /// Выполнить
        /// </summary>
        void Execute();
    }
}
