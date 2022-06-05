using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoParallelCheckSpelling
{
    class Program
    {
        static void Main(string[] args)
        {
            // зашружем хэш массив словами (для быстрого поиска)
            var wordsHash =
                new List<string>(
                    File.ReadAllLines("allwords.txt")
                    );
            // список для быстрого выбора
            var wordsList = wordsHash.ToList();
            // создадим документ из 100000 случайных слов
            var rnd = new Random();
            var document = Enumerable
                .Range(1, 10000)
                .Select(i => wordsList[rnd.Next(0, wordsList.Count)])
                .ToArray();
            // сделаем случайные ошибки в тексте
            document[8147] = "woozz";
            document[8541] = "xxwwll";
            // поиск ошибок в документе
            var sw = new Stopwatch();
            sw.Start();
            var query = document
                .Select((w, i) => new { Word = w, Index = i })
                .Where(x => !wordsHash.Contains(x.Word))
                .OrderBy(x => x.Index)
                .ToArray();
            sw.Stop();
            // на выходе массив из записей
            // ошибочное слово и его место в документе
            Console.WriteLine("time={0}", sw.ElapsedTicks);
            Console.WriteLine("Errors:");
            foreach (var item in query)
            {
                Console.WriteLine("Word={0}, Index={1}",
                    item.Word, item.Index);
            }
            sw.Reset();
            Console.ReadLine();
            //------------
            sw.Start();
            var query2 = document
                .AsParallel()
                .Select((w, i) => new { Word = w, Index = i })
                .Where(x => !wordsHash.Contains(x.Word))
                .OrderBy(x => x.Index)
                .ToArray();
            sw.Stop();
            // на выходе массив из записей
            // ошибочное слово и его место в документе
            Console.WriteLine("time={0}", sw.ElapsedTicks);
            Console.WriteLine("Errors:");
            foreach (var item in query2)
            {
                Console.WriteLine("Word={0}, Index={1}",
                    item.Word, item.Index);
            }
        }
    }
}
