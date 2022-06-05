using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStaticAndDynamicDecomposition
{
    class Program
    {
        static void Main(string[] args)
        {
            // инициализация
            var jobs = new List<Job>();
            for (int i = 10; i < 100; i++)
            {
                jobs.Add(new Job(i));
            }
            Console.WriteLine("Jobs готовы!");
            var sw = new Stopwatch();
            //-----------------------------------------
            Console.WriteLine("1) без параллельности");
            sw.Reset();
            Console.ReadLine();
            sw.Start();
            jobs.ForEach(j => j.Do());
            sw.Stop();
            Console.WriteLine("Итого ={0}", sw.ElapsedTicks);
            Console.WriteLine();
            //-----------------------------------------------
            Console.WriteLine("2) параллельно, но статическая декомпозиция");
            sw.Reset();
            Console.ReadLine();
            sw.Start();
            // jobs.ForEach(j => j.Do());
            Parallel.ForEach(jobs, j => j.Do());
            sw.Stop();
            Console.WriteLine("Итого ={0}", sw.ElapsedTicks);
            Console.WriteLine();
            //------------------------------------------------
            Console.WriteLine("3) параллельно, но динамич/блочная декомпозиция");
            sw.Reset();
            Console.ReadLine();
            sw.Start();
            Parallel.ForEach( Partitioner.Create(jobs, true), j => j.Do());
            sw.Stop();
            Console.WriteLine("Итого ={0}", sw.ElapsedTicks);
            Console.WriteLine();

            Console.ReadLine();

        }
    }
}
