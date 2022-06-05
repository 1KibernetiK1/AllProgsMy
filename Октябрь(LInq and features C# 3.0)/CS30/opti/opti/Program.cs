using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opti
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Оптимизация работы со строками");
            //Задача - склеивание текста из кусочков
            string text = "числа: ";
            for (int i = 1; i <1000; i++)
            {
                //text += string st = (string)mass[1];
                // создается новая строка большего размера
                // в неё из старой копируются все данные + добавляются массива
            }
            Console.WriteLine(text);

            // для решения проблемы - класс stringBuilder
            var sb = new StringBuilder("числа: ");
            for (int i = 1; i < 1000; i++)
            {
                sb.Append(", " + i.ToString());
            }
            string result = sb.ToString();

            Console.ReadLine();
        }
    }
}
