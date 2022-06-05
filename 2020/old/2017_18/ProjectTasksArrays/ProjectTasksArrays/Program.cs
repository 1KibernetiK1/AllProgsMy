using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTasksArrays
{
    class Program
    {
        static void FillRandom(int[] m)
        {
            Random rnd = new Random();
            for (int i = 0; i < m.Length; i++)
            {
                m[i] = rnd.Next(0, 100);
            }
        }

        static void Print(int[] m)
        {
            for (int i = 0; i < m.Length; i++)
            {
                Console.Write("{0}, ", m[i]);
            }
            Console.WriteLine();
        }

        // создание полной копии  массива
        static int[] CloneArray(int[] m)
        {
            // размер копии?
            int[] clone = new int[ m.Length ];
            // копируем поштучно элементы
            for (int i = 0; i < m.Length; i++)
            {
                clone[i] = m[i];
            }
            // возвращаем результат
            return clone;
        }

        // копируем из одного массива в другой
        // несколько чисел с заданной позиции
        // в первом массиве в заданную поз во втором
        // m1 - первый массив
        // pos1 - позиция с котор копируем из первого
        // amount - кол-во эл-в кот нужно копировать
        // m2- второй массив
        // pos2  - позиция куда копируем во втором
        static void CopyItems(int[] m1, int pos1, 
                              int amount, 
                              int[]m2, int pos2)
        {
            // цикл - считает сколько копировать
            int i1 = pos1;
            int i2 = pos2;
            // защита от выхода за границу m1
            int diff1 = m1.Length - pos1;
            if (diff1 < amount)
            {
                amount = diff1;
            }
            // защита от выхода за границу m2
            int diff2 = m2.Length - pos2;
            if (diff2 < amount)
            {
                amount = diff2;
            }
            //-------------------------
            for (int i = 0; i < amount; i++)
            {
                m2[i2 + i] = m1[i1 + i];
            }
        }

        static void Main(string[] args)
        {
            int[] mass = new int[10];
            FillRandom(mass);
            Print(mass);
            Console.WriteLine("клонирование");
            int[] clone = CloneArray(mass);
            Print(mass);
            Console.WriteLine("Копирование");
            int[] mass2 = new int[15];
            Print(mass2);
            CopyItems(mass, 8, 4, mass2, 10);
            Print(mass2);
            Console.ReadLine();
        }
    }
}
