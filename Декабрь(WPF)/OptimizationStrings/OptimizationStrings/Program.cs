using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizationStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            


            Console.WriteLine("Оптимизация работы со строками");
            // Задача - склейка текста из кусочков
            Stopwatch stopwatch = new Stopwatch();
            // Так делать не надо!
            string text = "числа: ";
            for (int i = 1; i < 1000; i++)
            {
                text += ", " + i.ToString();
            }

            Console.WriteLine(text);

            stopwatch.Start();
            // для решения ПРОБЛЕМЫ - класс StringBuilder
            var sb = new StringBuilder("числа: ");
            for (int i = 1; i < 1000; i++)
            {
                sb.Append(", ");
                sb.Append(i.ToString());
            }
            Console.WriteLine(stopwatch.Elapsed);

            Console.ReadKey();
        }
    }
}
