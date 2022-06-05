using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project01Classic
{
    /// <summary>
    /// 1) шаг - класс нижнего уровня - "ДЕТАЛИ"
    /// </summary>
    public class Lamp
    {
        public Lamp()
        {
            Console.WriteLine("Создается лампа накаливания");
            Console.WriteLine("Детали: напряжение, контакты,....");           
        }

        public void Light()
        {
            Console.WriteLine("Даем напряжение - лампа светит!");
        }

        public void Dark()
        {
            Console.WriteLine("убираем напряжение - лампа не светит!");
        }
    }
}
