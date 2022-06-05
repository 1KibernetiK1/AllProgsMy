using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ProjectThreadPool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("работа с пулом:");
            // создадим 10 потоков (в пуле)
            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem((object o) =>
                {
                    Console.WriteLine("i:{0}, ThreadId:{1}, IsInPool: {2}",
                        i, 
                        Thread.CurrentThread.ManagedThreadId,
                        Thread.CurrentThread.IsThreadPoolThread);
                });
            }
            Thread.Sleep(2000);
            Console.WriteLine("DONE");

            Console.WriteLine("а теперь без пула:");
            Console.ReadLine();
            for (int i = 0; i < 10; i++)
            {
                new Thread((object o) =>
                {
                    Console.WriteLine("i:{0}, ThreadId:{1}, IsInPool: {2}",
                        i,
                        Thread.CurrentThread.ManagedThreadId,
                        Thread.CurrentThread.IsThreadPoolThread);
                }).Start();
            }
        }
    }
}
