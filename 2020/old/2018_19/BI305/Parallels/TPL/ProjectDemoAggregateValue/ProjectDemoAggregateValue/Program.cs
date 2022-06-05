using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectDemoAggregateValue
{
    class Program
    {
        static double Calc(double x)
        {
            Thread.Sleep(2);
            return Math.Sqrt(x);
        }

        static void Main(string[] args)
        {
            // заполним массив числами от 1 до 4000
            int[] data = Enumerable
                .Range(1, 1000)
                .ToArray();

            var sw = new Stopwatch();

            Console.WriteLine("1) без параллельности");
            Console.ReadLine();
            sw.Start();
            double agregate = 0;
            for (int i = 0; i < data.Length; i++)
            {
                agregate += Calc(data[i]);
            }
            sw.Stop();
            Console.WriteLine("время={0}",sw.ElapsedTicks);
            Console.WriteLine("ответ={0}", agregate);
            sw.Reset();
            Console.WriteLine();
            //--------------------------------------------
            Console.ReadLine();
            Console.WriteLine("2) параллельно");
            Console.ReadLine();
            sw.Start();
            agregate = 0;
            Parallel.For(0, data.Length, i =>
            {
                agregate += Calc(data[i]);
            });
            sw.Stop();
            Console.WriteLine("время={0}", sw.ElapsedTicks);
            Console.WriteLine("ответ={0}", agregate);
            Console.WriteLine("неверный рез-т, ГОНКА данных");
            sw.Reset();
            Console.WriteLine();
            //------------------------------------------------
            Console.ReadLine();
            Console.WriteLine("3) параллельно + lock");
            object obj = new object();
            sw.Start();
            agregate = 0;
            Parallel.For(0, data.Length, i =>
            {
                lock (obj)
                {
                    agregate += Calc(data[i]);
                }
            });
            sw.Stop();
            Console.WriteLine("время={0}", sw.ElapsedTicks);
            Console.WriteLine("ответ={0}", agregate);
            Console.WriteLine("неверный рез-т, ГОНКА данных");
            sw.Reset();
            Console.WriteLine();
            //--------------------------------------------
            Console.ReadLine();
            Console.WriteLine("4) параллельно + Aggregate");
            sw.Start();
            agregate = 0;

            // <double> - тип в котором аггрегирование
            Parallel.For<double>(0, data.Length,
                      () => 0, // 0 - в каждом потоке начальное знач
                      (i, state, sub) =>
                      { // sub - локальная (в каждом потоке - своя) перемнная для аггрегирования
                          sub += Calc(data[i]);
                          // этот кусок - агрегирование в отдельном потоке
                          return sub; // и его результат 
                      },

                      (x) => // x - результат с каждого потока
                      { // собираем все результаты со всех потоков в одну кучу
                          lock (obj)
                          { // блокируем ячейку и собираем всё в кучу!
                              agregate += x;
                          }
                      });


            sw.Stop();
            Console.WriteLine("время={0}", sw.ElapsedTicks);
            Console.WriteLine("ответ={0}", agregate);
            Console.WriteLine("неверный рез-т, ГОНКА данных");
            sw.Reset();
            Console.WriteLine();
        }
    }
}
