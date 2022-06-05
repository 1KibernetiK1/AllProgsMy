using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastingAndTypeOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Операции приведения и проверки типа");

            object[] mass = { 10, 20, "привет", 50, "как дела?", 60, "ok" };

            Console.WriteLine("выбрать только числа и положить в новый массив");
            int[] numbers = mass.OfType<int>().Cast<int>().ToArray();

            Console.WriteLine("m2 = {0}", string.Join(", ", numbers));

            Console.WriteLine("выбрать только текст и в новый массив");
            var m3 = mass.OfType<string>().Cast<string>().ToArray();

            var onlyNums = from s in mass
                           where s is int
                           select s;

            foreach (var n in onlyNums)
            {
                Console.WriteLine(n);
            }

            // OfType<string>()
            if (mass[2] is string)
            {            
                // Cast<string>()
                string st = (string)mass[2];
            }

            Console.Read();
        }
    }
}
