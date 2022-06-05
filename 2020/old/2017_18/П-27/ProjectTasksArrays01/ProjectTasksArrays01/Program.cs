using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTasksArrays01
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

        static void PrintArray(int[]m)
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
            PrintArray(mas);
            // 1) поиск минимального эл-та
            Console.WriteLine("1) поиск минимального эл-та");
            // ищем минимальный
            int min = FindMin(mas);
            Console.WriteLine("min={0}", min);
            // ищем макс
            int max = FindMax(mas);
            Console.WriteLine("max={0}", max);

            Console.ReadLine();
        }
    }
}
