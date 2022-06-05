using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project01Classic
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Классика:проектирование снизу вверх");
            Console.WriteLine("2 слоя: система управления освещением");

            // почти как третий слой - Бизнес логика
            Button btn = new Button(); // созд кнопку
            while (true) // ожидание включения
            {
                // в/д c юзером
                Console.ReadKey();

                btn.Click();
            }

            Console.ReadLine();
        }
    }
}
