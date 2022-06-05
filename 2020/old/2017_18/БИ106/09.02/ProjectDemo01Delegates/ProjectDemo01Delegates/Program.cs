using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDemo01Delegates
{
    // public delegate int Operation(int a, int b);
    public delegate int Operation<T>(T a, T b);
    
    class Program
    {
        static int Addition(int a, int b)
        {
            return a + b;
        }

        static void Main(string[] args)
        {
            Calculator calc = new Calculator();

            Operation<int> add = new Operation<int>(Addition);
            // для создания нового делегата new Operation - необязательно
            Operation<int> sub = calc.Subtraction;

            Console.WriteLine( add(3,7) );
            Console.WriteLine( sub(15,7) );

            Operation<int> ops = null;
            int number = 1;
            switch (number)
            {
                case 1: ops = add;break;
                case 2: ops = sub;break;
            }
            Console.WriteLine(ops(10, 8));
            // массив с методами
            Operation<int>  [] actions =
                {Addition, calc.Subtraction};
        }
    }
}
