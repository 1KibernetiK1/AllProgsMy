using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectPLINQ_DataPartition
{
    class Program
    {
        static void Main(string[] args)
        {
            // список задач с разным временем выполнения
            var jobs = Enumerable
                .Range(1, 100)
                .Select(x => new Job(x))
                .ToList();
            var sw = new Stopwatch();
            //-------------------------------------- 
            Console.WriteLine("1) последовательный");
            sw.Start();
            var request1 = jobs
                .Select(j => j.Do() * 2)
                .ToArray();
            sw.Stop();
            
            Console.WriteLine("Время ={0}",
                    sw.ElapsedMilliseconds);
            sw.Reset();
            //----------------------------------------
            Console.WriteLine("2) паралелльный, range partition");
            sw.Start();
            var request2 = jobs
                .AsParallel()
                .Select(j => j.Do() * 2)
                .ToArray();
            sw.Stop();
            
            Console.WriteLine("Время ={0}",
                    sw.ElapsedMilliseconds);
            sw.Reset();
            //----------------------------------------
            Console.WriteLine("3) паралелльный, block partition");
            sw.Start();
            var request3 = 
                Partitioner.Create(jobs,true)
                .AsParallel()
                .Select(j => j.Do() * 2)
                .ToArray();
            sw.Stop();
            
            Console.WriteLine("Время ={0}",
                    sw.ElapsedMilliseconds);
            sw.Reset();
            Console.ReadLine();
        }
    }

    public class Job
    {   // имитируем ситуацию - разное время 
        // обработки данных
        private int _value;

        public Job(int value)
        {
            _value = value;
        }

        public int Do()
        {
            Thread.Sleep(_value);
            return _value;
        }
    }
}
