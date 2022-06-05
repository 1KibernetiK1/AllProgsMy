using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSorting
{
    class Program
    {
        // заполнение массива случайными числами
        static void FillRandom(int[] m)
        {
            Random rnd = new Random();
            for (int i = 0; i < m.Length; i++)
            {
                m[i] = rnd.Next(0,100);
            }
        }

        // вывод на экран
        static void Print(int[] m)
        {
            for (int i = 0; i < m.Length; i++)
            {
                Console.Write("{0}, ", m[i]);
            }
            Console.WriteLine();
        }

        static void PrintVisual(int[] m, int c1, int c2)
        {
            for (int i = 0; i < m.Length; i++)
            {
                if (i == c1)
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                } else
                if (i == c2)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.White;
                } else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.Write("{0}, ", m[i]);
            }
            Console.WriteLine();
        }

        static void PrintVisualSwap(int[] m, int c1, int c2)
        {
            for (int i = 0; i < m.Length; i++)
            {
                if (i == c1)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                if (i == c2)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.Write("{0}, ", m[i]);
            }
            Console.WriteLine();
        }

        static void BubbleSort(int[] m)
        {
            // цикл для каждого элемента массива
            // кроме последнего
            for (int i = 0; i < m.Length-1; i++)
            {
                // i - номер текущего элемента
                // каждый нужно сравнить со всеми последующими
                for (int j = i+1; j < m.Length; j++)
                {
                    // j - номер последующего
                    if (m[j] <  m[i])
                    {
                        // меняем местами
                        int c = m[j];
                        m[j] = m[i];
                        m[i] = c;
                    }
                }
            }
        }

        static void BubbleSortVisual(int[] m)
        {
            // цикл для каждого элемента массива
            // кроме последнего
            for (int i = 0; i < m.Length - 1; i++)
            {
                // i - номер текущего элемента
                // каждый нужно сравнить со всеми последующими
                for (int j = i + 1; j < m.Length; j++)
                {
                    PrintVisual(m, i, j);
                    Console.ReadKey(true);
                    // j - номер последующего
                    if (m[j] < m[i])
                    {
                        PrintVisualSwap(m,i,j);
                        Console.ReadKey(true);
                        // меняем местами
                        int c = m[j];
                        m[j] = m[i];
                        m[i] = c;
                        PrintVisualSwap(m, i, j);
                        Console.ReadKey(true);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            int[] mas = new int[10];
            FillRandom(mas);
            Print(mas);
            Console.WriteLine("после сортировки:");
            BubbleSortVisual(mas);
            Print(mas);
            Console.ReadLine();
        }
    }
}
