using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ProjectThreadPoolWait
{
    class Program
    {

        static void Work(object obj)
        {
            // сигнальный класс
            var mre = (ManualResetEvent)obj;
            // вычисления
            Console.WriteLine("calc....");
            for (int i = 0; i < 1000; i++)
            {
                Thread.Sleep(2);
            }
            // сигнал о завершении...
            mre.Set();
        }

        static void Main(string[] args)
        {
            var mre = new ManualResetEvent(false);
            ThreadPool.QueueUserWorkItem(Work, mre);
            mre.WaitOne(); // ждём сигнала
            
            Console.WriteLine("Done!");

            Console.ReadLine();
        }
    }
}
