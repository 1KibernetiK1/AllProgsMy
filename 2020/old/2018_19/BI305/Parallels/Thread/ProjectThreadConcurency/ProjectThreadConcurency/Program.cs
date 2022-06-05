using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ProjectThreadConcurency
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;

            var th1 = new Thread(() =>
            {
                for (int i = 0; i < 200; i++)
                {
                    counter++;
                    Thread.Sleep(2);
                }          
            });
            var th2 = new Thread(() =>
            {
                for (int i = 0; i < 200; i++)
                {
                    counter++;
                    Thread.Sleep(2);
                }
            });
            var th3 = new Thread(() =>
            {
                for (int i = 0; i < 200; i++)
                {
                    counter++;
                    Thread.Sleep(2);
                }
            });
            th1.Start();
            th2.Start();
            th3.Start();

            th1.Join(); th2.Join(); th3.Join();
            Console.WriteLine("counter={0}", counter);
            Console.ReadLine();
            Console.WriteLine("counter={0}", counter);
        }
    }
}
