using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ProjectDemoParallelFOR
{
    class Program
    {
        static double[] mass1;
        static double[] mass2;
        static double[] result;

        static void Initialize(int size)
        {
            mass1 = new double[size];
            mass2 = new double[size];
            result = new double[mass1.Length];
            var rnd = new Random();
            for (int i = 0; i < size; i++)
            {
                mass1[i] = rnd.Next();
                mass2[i] = rnd.Next();
            }
        }

        static double[] Multiply()
        {
            for (int i = 0; i < mass1.Length; i++)
            {
                result[i] = mass1[i] * mass2[i];
                Thread.Sleep(10);
            }
            return result;
        }

        static double[] MultiplyParallel()
        {
            
            var opt = new ParallelOptions()
            {
                MaxDegreeOfParallelism = 4
            };
            Parallel.For(0, result.Length,opt, i =>
            {
                result[i] = mass1[i] * mass2[i];
                Thread.Sleep(10);
            });
            return result;
        }

        static void Main(string[] args)
        {
            int size = 500;
            Initialize(size);
            Console.WriteLine("Готово");
            var sw = new Stopwatch();
            Console.ReadLine();
            //----------------------------
            sw.Start();
            var result1 = Multiply();
            sw.Stop();
            Console.WriteLine("usual={0}",
                sw.ElapsedTicks);
            //----------------------------
            sw.Reset();
            Console.ReadLine();
            sw.Start();
            result1 = MultiplyParallel();
            sw.Stop();
            Console.WriteLine("parallel={0}",
                sw.ElapsedTicks);

            Console.ReadLine();
        }
    }
}
