using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feature8
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
}
