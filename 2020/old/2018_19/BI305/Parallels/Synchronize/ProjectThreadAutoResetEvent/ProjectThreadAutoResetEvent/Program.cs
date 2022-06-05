using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ProjectThreadAutoResetEvent
{
    class Program
    {
        static AutoResetEvent ready = new AutoResetEvent(false);
        static AutoResetEvent go = new AutoResetEvent(false);
        static string sharedText;

        static void Work()
        {
            while(true)
            {
                ready.Set(); // сигнал готовности
                go.WaitOne(); // ожидаем сигнал НАЧАТЬ

                if (sharedText == null) break;
                Console.WriteLine(sharedText); 
            }
        }

        static void Main(string[] args)
        {
            sharedText = null;
            // запускаем поток
            new Thread(Work).Start();

            for (int i = 0; i < 10; i++)
            {
                ready.WaitOne(); // ждём когда поток готов!
                sharedText = "H".PadRight(i, 'e');
                go.Set(); // говорим поток - работать
            }
            ready.WaitOne(); // Ждём потоки
            sharedText = null;
            go.Set(); // работать с пустой строкой - выход
            Console.ReadLine();
        }
    }
}
