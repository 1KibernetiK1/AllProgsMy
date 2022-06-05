using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ProjectThreadOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            var th1 = new Thread(() =>
            {
                for (int i = 0; i < 15; i++)
                {
                    Console.Write("A");
                }
            });
            var th2 = new Thread(() =>
            {
                for (int i = 0; i < 15; i++)
                {
                    Console.Write("B");
                }
            });
            var th3 = new Thread(() =>
            {
                for (int i = 0; i < 15; i++)
                {
                    Console.Write("C");
                }
            });
            th1.Start();
            th2.Start();
            th3.Start();

            th1.Join(); th2.Join(); th3.Join();

            Console.ReadLine();
        }
    }
}
