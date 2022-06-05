using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnozhestva
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Операции со множествами");
            int[] m1 = { 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] m2 = { 7, 8, 9, 10, 11, 12, 13, 14 };
            Console.WriteLine("m1 = {0}", string.Join(", ", m1));
            Console.WriteLine("m2 = {0}", string.Join(", ", m2));

            Console.WriteLine("1) объединение коллекций:");
            var m3 = m1.Union(m2).ToArray();
            Console.WriteLine("m3 = {0}", string.Join(", ", m3));

            Console.WriteLine("2) операция исключения");
            var m4 = m1.Except(m2).ToArray();
            Console.WriteLine("m4 = {0}", string.Join(", ", m4));

            Console.WriteLine("3) Пересечение коллекций");
            var m5 = m1.Intersect(m2).ToArray();
            Console.WriteLine("m5 = {0}", string.Join(", ", m5));

            Console.WriteLine("4) Убирает повторы из коллекций");
            int[] a1 = { 10, 20, 30, 40, 40, 50, 50, 60, 70 };
            Console.WriteLine("a1= {0}", string.Join(", ", a1));
            int[] a2 = a1.Distinct().ToArray();
            Console.WriteLine("a2= {0}", string.Join(", ", a2));

            Console.ReadLine();
        }
    }
}
