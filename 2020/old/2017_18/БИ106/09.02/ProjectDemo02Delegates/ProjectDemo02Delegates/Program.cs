using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDemo02Delegates
{
    public delegate int Op(int a);

    class Program
    {
        static int[] mass = { 2, 4, 6, 8, 10 };

        static void Processing(int[] m, Op operate)
        {
            for (int i = 0; i < m.Length; i++)
            {
                mass[i] = operate(mass[i]);
            }
        }

        static int Square(int a)
        {
            return a * a;
        }

        static void PrintArray(int[] m)
        {
            foreach (var item in m)
            {
                Console.Write("{0}, ", item);
            }
            Console.WriteLine();
        }
        

        static void Main(string[] args)
        {
            Console.WriteLine("исходный");
            PrintArray(mass);
            // 1) способ - передача 
            // метода (полноценного)
            Processing(mass, Square);

            Console.WriteLine("квадрат");
            PrintArray(mass);

            // C# 2.0
            // 2) анонимный делегат
            // -одноразовый безымянный метод
            Processing(mass, delegate (int a) { return a - 3; });
            Console.WriteLine("минус 3");
            PrintArray(mass);

            // C# 3.0
            // 3) использваоние лямбда выражения
            Processing(mass, a => a+10);
            Console.WriteLine("плюс 10");
            PrintArray(mass);
            
        }
    }
}
