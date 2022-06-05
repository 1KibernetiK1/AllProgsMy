using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFindMinVisual
{
    class Program
    {
        static void FillRandom(int[] m)
        {
            Random rnd = new Random();
            for (int i = 0; i < m.Length; i++)
            {
                m[i] = rnd.Next(1, 100);
            }
        }

        static void PrintArray(int[] m)
        {
            for (int i = 0; i < m.Length - 1; i++)
            {
                Console.Write("{0}, ", m[i]);
            }
            Console.WriteLine("{0}", m[m.Length - 1]);
        }

        // ищем максимальный
        static int FindMax(int[] m)
        {
            // берём в руку первый эл-т
            int hand = m[0];
            // сравниваем 0-й со всеми остальными
            for (int i = 1; i < m.Length; i++)
            {
                // если некто меньше, чем в руке
                if (m[i] > hand)
                {
                    // мы его в руку кладём
                    hand = m[i];
                }
            }
            // все элементы проверили
            return hand;
        }

        // найти минимальный
        static int FindMin(int[] m)
        {
            // берём в руку первый эл-т
            int hand = m[0];
            // сравниваем 0-й со всеми остальными
            for (int i = 1; i < m.Length; i++)
            {
                // если некто меньше, чем в руке
                if (m[i] < hand)
                {
                    // мы его в руку кладём
                    hand = m[i];
                }
            }
            // все элементы проверили
            return hand;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Типовые задачи с массивами");
            // массив объявляем и создаём
            int[] mas = new int[12];
            // массив заполняем случ
            FillRandom(mas);
            // печатаем
            int hand = mas[0];
            int i = 1;
            while(i<mas.Length)
            {
                Console.Clear();
                PrintArray(mas);
                Console.WriteLine("  визуализируем поиск миним");
                Console.WriteLine("  в руке число ={0}", hand);
                Console.WriteLine("  сравниваем с элементом {0} по индексу {1}",mas[i], i);
                if (mas[i] < hand)
                {
                    Console.WriteLine("  элемент оказался меньше, чем у нас в руке!");
                    Console.WriteLine("  берём его в руку!");
                    hand = mas[i];
                } else
                {
                    Console.WriteLine("  элемент оказался больше, чем у нас в руке!");
                }
                Console.WriteLine("нажмите любую кнопку для продолжения");
                Console.ReadKey();
                i++;
            }
            Console.WriteLine();
            Console.WriteLine("сравнили со всеми элементами!");
            Console.WriteLine("min = {0}", hand);
            Console.ReadLine();
        }
    }
}
