using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLinq01
{
    public static class ArrayExtension
    {
        public static void Print(this int[] m) // Сюда можно писать любой параметр, в который мы хотим добавит, метод
        {
            for (int i = 0; i < m.Length; i++)
            {
                Console.WriteLine("{0},", m[i]);
            }
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("DEMO Linq");
            // задача - из массива целых чисел выбрать все четные и записать их в новый массив

            int[] mas1 = { 10, 13, 14, 15, 16, 17, 18, 20 };
            // C# 2.0
            int counter = 0;
            for (int i = 0; i < mas1.Length; i++)
            {
                if (mas1[i] % 2 == 0) counter++;
               
            }
            int[] mas2 = new int[counter];
            counter = 0;
            for (int i = 0; i < mas1.Length; i++)
            {
                if (mas1[i] % 2 == 0)
                {
                    mas2[counter] = mas1[i];
                    counter++;
                }

            }
            mas2.Print();
            //------------------------------------------------------------------------------------------

            // C#3.0 - Linq
            // 1) Способ через язык
            var mas3 = (from x in mas1 where x % 2 == 0 select x).ToArray();
            mas3.Print();

            // 2) способ - тоже самое, но через методы расширения
            var mas4 = mas1.Where(x => x % 2 == 0).ToArray();
            mas4.Print();

            Console.ReadLine();
        }
    }
}
