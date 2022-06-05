using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTasksArray
{
    class Program
    {
        // 1) заполнение случ числами
        static void FillArrayRandom(int[] mas)
        {
            // создать генератор случ чисел
            Random rnd = new Random();
            for(int i = 0; i < mas.Length; i++)
            {
                mas[i] = rnd.Next(0, 100);
            }
        }

        // 2) вывод массива на экран
        static void PrintArray(int[] m)
        {
            for (int i = 0; i < m.Length-1; i++)
            {
                Console.Write("{0}, ", m[i]);
            }
            int last = m.Length - 1;
            Console.WriteLine(m[last]);
        }

        // 3) заполнение массива юзером
        static void FillArrayUser(int[] m)
        {
            for(int i=0; i<m.Length; i++)
            {
                Console.Write("Введите mas[{0}] = ", i);
                string st = Console.ReadLine();
                int a = Convert.ToInt32(st);
                m[i] = a;
            }
        }

        // 4) поиск минимального
        static int FindMin(int[] mas)
        {
            int hand = mas[0];
            for(int i = 1; i < mas.Length; i++)
            {
                if ( mas[i] < hand)
                {
                    hand = mas[i];
                }
            }
            return hand;
        }

        static void Main(string[] args)
        {
            // создаём массив
            int[] m = new int[10];
            // заполним массив случ числами
            Console.WriteLine("заполнение случ числами");
            FillArrayRandom(m);
            // массив печатаем
            PrintArray(m);
            Console.WriteLine("Ввод массив вручную");
            FillArrayUser(m);
            PrintArray(m);
            Console.WriteLine("Поиск минимального:");
            int min = FindMin(m);
            Console.WriteLine("миним = {0}", min);
            Console.ReadLine();
        }
    }
}
