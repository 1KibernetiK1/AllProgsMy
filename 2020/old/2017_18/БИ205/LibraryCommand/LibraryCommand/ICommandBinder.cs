using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCommand
{
    /// <summary>
    /// Привязка команды к объекту
    /// </summary>
    public interface ICommandBinder
    {
        /// <summary>
        /// Метод привязки
        /// </summary>
        /// <param name="com">команда</param>
        /// <param name="source">объект</param>
        void Bind(ICommand com, object source);

        /// <summary>
        /// Описание типа объекта
        /// </summary>
        Type SourceType { get; }
    }
}
