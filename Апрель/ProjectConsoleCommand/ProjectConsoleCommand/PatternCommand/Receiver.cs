using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectConsoleCommand.PatternCommand
{
    /// <summary>
    /// 2)  шаг - исполнитель действий
    /// "Получатель команды"
    /// (Испольнитель ничего не знает про интерфейс пользователя)
    /// </summary>
    public class Receiver
    {
        public void CalculateSalary()
        {
            Console.WriteLine("Бизнес-логика - считаем зарплату");
        }
    }
}
