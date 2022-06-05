using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ProjectThreadPoolWaitMany
{
    class Program
    {
        static void Main(string[] args)
        {
            var mrs = new ManualResetEvent[10];
            for (int i = 0; i < 10; i++)
            {
                int y = i;
                mrs[i] = new ManualResetEvent(false);
                ThreadPool.QueueUserWorkItem((a) =>
                {
                    for (int j = 0; j < 20; j++)
                    {
                        Thread.Sleep(2);
                    }
                    mrs[y].Set(); // сигнал завершения
                });
            }

            // ожидаем завершения..
            WaitHandle.WaitAll(mrs);
            // WaitAny()
            Console.WriteLine("Done");

            Console.ReadLine();
        }
    }
}
