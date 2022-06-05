using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ProjectThreadSync01
{
    class Program
    {
        static int x = 0;

        static object locker = new object();

        // иллюстрация ГОНКИ ПОТОКОВ
        // когда значение переменной может
        // стать НЕПРЕДСКАЗУЕМЫМ
        // (неск-ко потоков одновременно меняют значение)
        // а запоминается одно
        static void WorkCount1()
        {
            x = 1;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("TH {0}, x={1}",
                    Thread.CurrentThread.ManagedThreadId,
                    x);
                x++;
                Thread.Sleep(100);
            }
        }

        // используем блокировку перемнной x
        // с помощью МОНИТОРА
        static void WorkCount2()
        {
            Monitor.Enter(locker);
            try
            {
                x = 1;
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("TH {0}, x={1}",
                        Thread.CurrentThread.ManagedThreadId,
                        x);
                    x++;
                    Thread.Sleep(100);
                }
            }
            finally
            {
                Monitor.Exit(locker);
            }
        }

        // блокировка с помощью lock
        static void WorkCount3()
        {
            lock (locker)
            {
                x = 1;
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("TH {0}, x={1}",
                        Thread.CurrentThread.ManagedThreadId,
                        x);
                    x++;
                    Thread.Sleep(100);
                }
            }
        }

        // блокируем участки, где меняется переменная
        static void WorkCount4()
        {
            // lock (locker) { x = 1; };
            for (int i = 0; i < 10; i++)
            {
                lock (locker)
                {
                    Console.WriteLine("TH {0}, x={1}",
                        Thread.CurrentThread.ManagedThreadId,
                        x);
                    x++;
                }
                Thread.Sleep(100);
            }
        }

        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                var th = new Thread(WorkCount4);
                th.Start();
            }
            Console.ReadLine();
        }
    }
}
