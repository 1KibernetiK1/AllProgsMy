using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace privedenieAndProvtipov
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Операции приведения и проверки типов");
            object[] mass = { 10, 20, "Привет", 50, "Как дела", 60, "ок" };

            Console.WriteLine("выбрать только числа и в новый массив");
            var m2 = mass.OfType<int>().Cast<int>().ToArray();
            Console.WriteLine("m2= {0}", string.Join(", ", m2));

            Console.WriteLine("Выбрать только текст");
            //var m3 = mass.OfType<string>().Cast<string>().ToArray();
            // Console.WriteLine("m3= {0}", string.Join(", ", m3));

            //OfType<string>()
            if (mass[2] is string)
            {
                //Cast<string>()
                string st = (string)mass[1];
            }

            Console.ReadLine();
        }
    }
}
