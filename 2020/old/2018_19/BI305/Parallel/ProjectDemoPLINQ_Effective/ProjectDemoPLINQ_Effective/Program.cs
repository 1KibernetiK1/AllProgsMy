using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace ProjectDemoPLINQ_Effective
{
    class Program
    {
        static int Project(int x)
        {
            // долгая обработка...
            Thread.Sleep(5);
            return x;
        }

        static void Main(string[] args)
        {
            var sw = new Stopwatch();
            // 1) вариант
            var query1 =
                Enumerable.Range(1, 1000)
                .Select(x => Project(x))
                .Where(x => x % 2 == 0)
                .AsParallel();
            sw.Start();
            int c1 = query1.Count();
            sw.Stop();
            Console.WriteLine("1)й вариант={0}",
                              sw.ElapsedMilliseconds);
            sw.Reset();
            //----------------------------------------
            // 2) вариант
            var query2 =
                Enumerable.Range(1, 1000)
                .AsParallel()
                .Select(x => Project(x))
                .Where(x => x % 2 == 0);
            sw.Start();
            int c2 = query2.Count();
            sw.Stop();
            Console.WriteLine("2)й вариант={0}",
                              sw.ElapsedMilliseconds);
            sw.Reset();
            //----------------------------------------
            // 3) вариант
            var query3 =
                Enumerable.Range(1, 1000)
                .Select(x => Project(x))
                .AsParallel()
                .Where(x => x % 2 == 0);
            sw.Start();
            int c3 = query2.Count();
            sw.Stop();
            Console.WriteLine("3)й вариант={0}",
                              sw.ElapsedMilliseconds);
            Console.ReadLine();
        }
    }
}
