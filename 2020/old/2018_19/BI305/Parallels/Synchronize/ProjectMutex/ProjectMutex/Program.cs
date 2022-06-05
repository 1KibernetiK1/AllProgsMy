using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectMutex
{
    class Program
    {
        static void Main(string[] args)
        {
            // пример - запрет запуска второй копии приложения
            var mutex = new Mutex(false, "My Application v1.0");
            if (!mutex.WaitOne(TimeSpan.FromSeconds(2), false))
            {
                Console.WriteLine("Приложение уже запущено");
                Console.WriteLine("Запуск копии запрещён!");
                Console.ReadLine();
                return;
            }
            Console.Write("Work");
            while(true)
            {
                Console.Write(".");
                Thread.Sleep(300);
            }
        }
    }
}
