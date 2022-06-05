using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feature7
{
    public delegate int Function(int x);

    public delegate int MethodTwo(int a, int b); // любые параметры и типы можно добавлять за место инта

    class Program
    {
        public static void Processing(int[] m, Function f)
        {
            for (int i = 0; i < m.Length; i++)
            {
                m[i] = f(m[i]);
            }
        }

        // 1й вариант - простой - написать полный метод для делегата
        static int AddOne(int x)
        {
            return x + 1;
        }

        static void Main(string[] args)
        {
            int[] m1 = { 2, 4, 6, 8, 10 };
            // 1й вариант
            // полный синтаксис
            Processing(m1, new Function(AddOne));
            // Сокращенный синтаксис
            Processing(m1, AddOne);

            // 2й вариант (C#2.0)
            // умножение все на 2
            Processing(m1, new Function(delegate (int a) { return a * 2; }));
            // сокр вариант
            Processing(m1, delegate (int a) { return a * 2; });

            // добавлен лямбда оператор (C#3.0)
            Processing(m1, x => x * 3); // => x*3 - создается функция без имени

            Function mult4 = x => x * 4;

            Console.WriteLine(mult4(2));

            MethodTwo add = (x, y) => x + y;

            Func<int, int, int> add2 = (x, y) => x + y;

            Console.WriteLine(add(2,3));

            Console.ReadLine();
        }
    }
}
